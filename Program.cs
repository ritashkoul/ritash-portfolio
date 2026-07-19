using System.Threading.RateLimiting;
using Microsoft.AspNetCore.HttpOverrides;
using Portfolio.Services;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------------------------------------------------
// OWASP A05:2021 (Security Misconfiguration) - don't advertise the stack
// ---------------------------------------------------------------------
builder.WebHost.ConfigureKestrel(options =>
{
    options.AddServerHeader = false; // removes the "Server: Kestrel" header

    options.Limits.MaxRequestBodySize = 512 * 1024; // 512 KB - this site has no forms or uploads
    options.Limits.MaxRequestHeaderCount = 40;
    options.Limits.MaxRequestHeadersTotalSize = 32 * 1024;
    options.Limits.RequestHeadersTimeout = TimeSpan.FromSeconds(10);
});

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor |
        ForwardedHeaders.XForwardedProto;
});

builder.Services.AddRazorPages();

// ---------------------------------------------------------------------
// Daily quote (About page). Fetched server-side, not from the browser -
// the visitor's browser never talks to ZenQuotes directly, so the strict
// CSP (default-src 'self') needs no new exceptions for this. The request
// URL is hardcoded, never built from user input, so this isn't an SSRF
// surface (OWASP A10:2021) despite being an outbound call.
// ---------------------------------------------------------------------
builder.Services.AddHttpClient();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IQuoteService, QuoteService>();

// ---------------------------------------------------------------------
// OWASP A04:2021 (Insecure Design) - rate limit every request so a single
// client can't hammer the site. This is a static-content, read-only site,
// so this is mostly about basic scraping/DoS courtesy, not an attack surface.
// ---------------------------------------------------------------------
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
    {
        var key = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        return RateLimitPartition.GetFixedWindowLimiter(key, _ => new FixedWindowRateLimiterOptions
        {
            PermitLimit = 90,
            Window = TimeSpan.FromMinutes(1),
            QueueLimit = 0
        });
    });
});

builder.Services.AddResponseCompression();

var app = builder.Build();

app.UseForwardedHeaders();

// ---------------------------------------------------------------------
// OWASP A05:2021 - generic error handling, never leak stack traces
// ---------------------------------------------------------------------
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Error", "?code={0}");

// ---------------------------------------------------------------------
// OWASP A05:2021 / A03:2021 (XSS) - a strict, explicit security header set.
// No inline <script>/<style> anywhere in this project, so CSP can stay tight.
// ---------------------------------------------------------------------
app.Use(async (context, next) =>
{
    var headers = context.Response.Headers;

    headers.XContentTypeOptions = "nosniff";
    headers.XFrameOptions = "SAMEORIGIN";
    headers["Referrer-Policy"] = "strict-origin-when-cross-origin";
    headers["Permissions-Policy"] = "camera=(), microphone=(), geolocation=(), payment=()";
    headers["Cross-Origin-Opener-Policy"] = "same-origin";
    headers["Cross-Origin-Resource-Policy"] = "same-origin";
    headers.XXSSProtection = "0";

    headers.ContentSecurityPolicy =
        "default-src 'self'; " +
        "script-src 'self'; " +
        "style-src 'self'; " +
        "img-src 'self' data:; " +
        "font-src 'self'; " +
        "object-src 'none'; " +
        "base-uri 'self'; " +
        "form-action 'self'; " +
        "frame-ancestors 'self'; " +
        "upgrade-insecure-requests";

    headers.Remove("X-Powered-By");

    await next();
});

app.UseResponseCompression();
app.UseRateLimiter();

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.CacheControl = "public,max-age=86400";
    }
});

app.UseRouting();
app.MapRazorPages();

app.Run();
