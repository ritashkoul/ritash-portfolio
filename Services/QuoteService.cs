using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;

namespace Portfolio.Services;

public class QuoteService(IHttpClientFactory httpClientFactory, IMemoryCache cache, ILogger<QuoteService> logger) : IQuoteService
{
    private static readonly (string Text, string Author) Fallback =
        ("The only way to do great work is to love what you do.", "Steve Jobs");

    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly IMemoryCache _cache = cache;
    private readonly ILogger<QuoteService> _logger = logger;

    public async Task<(string Text, string Author)> GetDailyQuoteAsync()
    {
        // One cache entry per calendar day - matches "quote of the day" semantics
        // and keeps us well under ZenQuotes' free-tier rate limit (their API is
        // only actually hit once per day per running instance, not per visitor).
        var cacheKey = $"daily-quote-{DateTime.UtcNow:yyyy-MM-dd}";

        if (_cache.TryGetValue(cacheKey, out (string Text, string Author) cached))
        {
            return cached;
        }

        var result = await FetchFromZenQuotesAsync();
        _cache.Set(cacheKey, result, TimeSpan.FromHours(24));
        return result;
    }

    private async Task<(string Text, string Author)> FetchFromZenQuotesAsync()
    {
        try
        {
            var client = _httpClientFactory.CreateClient("ZenQuotes");
            client.Timeout = TimeSpan.FromSeconds(4); // never let a slow third party stall page loads

            using var response = await client.GetAsync("https://zenquotes.io/api/today");
            response.EnsureSuccessStatusCode();

            await using var stream = await response.Content.ReadAsStreamAsync();
            using var doc = await JsonDocument.ParseAsync(stream);

            var first = doc.RootElement[0];
            var text = first.GetProperty("q").GetString();
            var author = first.GetProperty("a").GetString();

            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(author))
            {
                return Fallback;
            }

            return (text, author);
        }
        catch (Exception ex)
        {
            // Network hiccup, timeout, unexpected response shape - never let a
            // third-party outage break the page. Fall back to a static quote.
            _logger.LogWarning(ex, "Could not fetch daily quote from ZenQuotes; using fallback.");
            return Fallback;
        }
    }
}