using Microsoft.AspNetCore.ResponseCompression;
using Portfolio.Extensions;
using Portfolio.Services;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.AddServerHeader = false;

    options.Limits.MaxRequestBodySize = 512 * 1024;
    options.Limits.MaxRequestHeaderCount = 40;
    options.Limits.MaxRequestHeadersTotalSize = 32 * 1024;
    options.Limits.RequestHeadersTimeout = TimeSpan.FromSeconds(10);
});

builder.Services.AddRazorPages();
builder.Services.AddMemoryCache();

builder.Services.AddHttpClient("ZenQuotes", client =>
{
    client.BaseAddress = new Uri("https://zenquotes.io/");
    client.Timeout = TimeSpan.FromSeconds(4);
});

builder.Services.AddScoped<IQuoteService, QuoteService>();

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute(
    "/Error",
    "?code={0}");

app.UseSecurityHeaders();

app.UseResponseCompression();

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = context =>
    {
        context.Context.Response.Headers.CacheControl =
            "public,max-age=86400";
    }
});

app.UseRouting();

app.MapGet("/health", () => Results.Ok("Healthy"));

app.MapRazorPages();

app.Run();