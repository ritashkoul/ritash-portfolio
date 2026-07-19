using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Services;

namespace Portfolio.Pages;

public class IndexModel(IQuoteService quoteService) : PageModel
{
    private readonly IQuoteService _quoteService = quoteService;

    public string QuoteText { get; private set; } = "";
    public string QuoteAuthor { get; private set; } = "";

    public async Task OnGetAsync()
    {
        (QuoteText, QuoteAuthor) = await _quoteService.GetDailyQuoteAsync();
    }
}
