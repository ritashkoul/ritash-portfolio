using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using Portfolio.Models;

namespace Portfolio.Services;

public sealed class QuoteService(
    IHttpClientFactory httpClientFactory,
    IMemoryCache cache,
    ILogger<QuoteService> logger)
    : IQuoteService
{
    private const string HttpClientName = "ZenQuotes";

    private static readonly Quote FallbackQuote =
        new(
            "The only way to do great work is to love what you do.",
            "Steve Jobs");

    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    private readonly IMemoryCache _cache = cache;

    private readonly ILogger<QuoteService> _logger = logger;

    public async Task<Quote> GetDailyQuoteAsync(CancellationToken cancellationToken = default)
    {
        var cacheKey = $"daily-quote-{DateTime.UtcNow:yyyy-MM-dd}";

        if (_cache.TryGetValue(cacheKey, out Quote? cachedQuote))
            return cachedQuote!;

        var quote = await FetchQuoteAsync(cancellationToken);
        _cache.Set(cacheKey, quote, TimeSpan.FromHours(24));

        return quote;
    }

    private async Task<Quote> FetchQuoteAsync(CancellationToken cancellationToken)
    {
        try
        {
            var client = _httpClientFactory.CreateClient(HttpClientName);

            using var response = await client.GetAsync("api/today", cancellationToken);

            response.EnsureSuccessStatusCode();

            await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);

            using var document =
                await JsonDocument.ParseAsync(
                    stream,
                    cancellationToken: cancellationToken);

            var firstQuote = document.RootElement[0];
            var text = firstQuote.GetProperty("q").GetString();
            var author = firstQuote.GetProperty("a").GetString();

            if (string.IsNullOrWhiteSpace(text) ||
                string.IsNullOrWhiteSpace(author))
            {
                return FallbackQuote;
            }

            return new Quote(text, author);
        }
        catch (OperationCanceledException)
            when (!cancellationToken.IsCancellationRequested)
        {
            _logger.LogWarning("ZenQuotes request timed out.");

            return FallbackQuote;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogWarning(ex, "ZenQuotes request failed.");

            return FallbackQuote;
        }
        catch (JsonException ex)
        {
            _logger.LogWarning(ex, "ZenQuotes returned an invalid response.");

            return FallbackQuote;
        }
    }
}