using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Portfolio.Pages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
public sealed class ErrorModel : PageModel
{
    public new int StatusCode { get; private set; } = 500;
    public string? RequestId { get; private set; }

    public void OnGet(int? code)
    {
        StatusCode = code ?? 500;
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
    }
}