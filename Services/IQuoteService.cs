namespace Portfolio.Services;

public interface IQuoteService
{
    Task<(string Text, string Author)> GetDailyQuoteAsync();
}