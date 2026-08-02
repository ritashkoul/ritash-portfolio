using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Pages;

public sealed class IndexModel(IQuoteService quoteService) : PageModel
{
    private readonly IQuoteService _quoteService = quoteService;

    public Quote? DailyQuote { get; private set; }

    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        DailyQuote = await _quoteService.GetDailyQuoteAsync(cancellationToken);
    }
}