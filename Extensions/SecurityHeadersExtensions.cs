namespace Portfolio.Extensions;

public static class SecurityHeadersExtensions
{
    public static IApplicationBuilder UseSecurityHeaders(
        this IApplicationBuilder app)
    {
        return app.Use(async (context, next) =>
        {
            var headers = context.Response.Headers;

            headers.XContentTypeOptions = "nosniff";
            headers.XFrameOptions = "SAMEORIGIN";
            headers.XXSSProtection = "0";

            headers["Referrer-Policy"] =
                "strict-origin-when-cross-origin";

            headers["Permissions-Policy"] =
                "camera=(), microphone=(), geolocation=(), payment=()";

            headers["Cross-Origin-Opener-Policy"] =
                "same-origin";

            headers["Cross-Origin-Resource-Policy"] =
                "same-origin";

            headers.ContentSecurityPolicy =
                string.Join(
                    ' ',
                    "default-src 'self';",
                    "script-src 'self';",
                    "style-src 'self';",
                    "img-src 'self' data:;",
                    "font-src 'self';",
                    "object-src 'none';",
                    "base-uri 'self';",
                    "form-action 'self';",
                    "frame-ancestors 'self';");

            await next();
        });
    }
}