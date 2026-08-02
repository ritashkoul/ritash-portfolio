using Portfolio.Models;

namespace Portfolio.Services;

public interface IQuoteService
{
    Task<Quote> GetDailyQuoteAsync(
        CancellationToken cancellationToken = default);
}