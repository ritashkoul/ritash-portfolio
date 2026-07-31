using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;

namespace Portfolio.Services;

public sealed class QuoteService(
    IHttpClientFactory httpClientFactory,
    IMemoryCache cache,
    ILogger<QuoteService> logger) : IQuoteService
{
    private static readonly (string Text, string Author) Fallback =
        (
            "The only way to do great work is to love what you do.",
            "Steve Jobs"
        );

    private readonly IHttpClientFactory _httpClientFactory =
        httpClientFactory;

    private readonly IMemoryCache _cache =
        cache;

    private readonly ILogger<QuoteService> _logger =
        logger;

    public async Task<(string Text, string Author)> GetDailyQuoteAsync()
    {
        var cacheKey =
            $"daily-quote-{DateTime.UtcNow:yyyy-MM-dd}";

        if (_cache.TryGetValue(
            cacheKey,
            out (string Text, string Author) cachedQuote))
        {
            return cachedQuote;
        }

        var quote = await FetchQuoteAsync();

        var cacheDuration = quote == Fallback
            ? TimeSpan.FromMinutes(30)
            : TimeSpan.FromHours(24);

        _cache.Set(cacheKey, quote, cacheDuration);

        return quote;
    }

    private async Task<(string Text, string Author)> FetchQuoteAsync()
    {
        try
        {
            var client =
                _httpClientFactory.CreateClient("ZenQuotes");

            using var cancellationTokenSource =
                new CancellationTokenSource(TimeSpan.FromSeconds(4));

            using var response = await client.GetAsync(
                "https://zenquotes.io/api/today",
                cancellationTokenSource.Token);

            response.EnsureSuccessStatusCode();

            await using var stream =
                await response.Content.ReadAsStreamAsync(
                    cancellationTokenSource.Token);

            using var document =
                await JsonDocument.ParseAsync(
                    stream,
                    cancellationToken: cancellationTokenSource.Token);

            var firstQuote =
                document.RootElement[0];

            var text =
                firstQuote.GetProperty("q").GetString();

            var author =
                firstQuote.GetProperty("a").GetString();

            return string.IsNullOrWhiteSpace(text)
                   || string.IsNullOrWhiteSpace(author)
                ? Fallback
                : (text, author);
        }
        catch (Exception exception)
        {
            _logger.LogWarning(
                exception,
                "Could not fetch the daily quote from ZenQuotes.");

            return Fallback;
        }
    }
}