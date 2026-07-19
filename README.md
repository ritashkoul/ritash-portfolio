# Portfolio — ASP.NET Core

Ritash Koul's personal portfolio: About, Experience, and a viewable +
downloadable résumé. No database, no login, no user input anywhere — the
simplest architecture that still looks and feels like a real, professional
site, hardened against the OWASP Top 10.

## What's on the site

- **About** (`/`) — bio, skills, education, résumé link, LinkedIn/Instagram/email
- **Experience** (`/Experience`) — a timeline of roles pulled from the résumé,
  each with the project worked on, a plain-language description, tech tags,
  and a link to the company's public website
- **Resume** (`/Resume`) — the résumé PDF viewable inline (via `<iframe>`,
  same-origin, no `object-src` exception needed) plus a direct download button

## Already filled in

- `Pages/Index.cshtml` — name, role, bio, skills, education (from the résumé)
- `Pages/Experience.cshtml.cs` — all 5 roles from the résumé, with company
  links verified against each company's real public site
- `wwwroot/resume/resume.pdf` — the actual résumé

## Still worth doing before you go live

1. `Pages/Index.cshtml` and `Pages/Shared/_Layout.cshtml` — the LinkedIn and
   Instagram links are still placeholders (`your-handle`) since I don't have
   those URLs. Search for `your-handle` and swap in your real profile links.
   Same for the GitHub link in the footer if you have/want one.
2. If you build any personal projects later, add them to `SideProjects` in
   `Pages/Experience.cshtml.cs` — that section only appears on the page once
   it has at least one entry.
3. Double-check the résumé PDF doesn't have personal metadata you don't want
   distributed (Author/Company fields in the file properties) - most PDF
   tools have a "remove personal information" option.

## Opening in Visual Studio

You'll need [Visual Studio 2022](https://visualstudio.microsoft.com/) (Community edition is free) with the **ASP.NET and web development** workload, or just the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) if you prefer the command line.

Double-click **`Portfolio.sln`** to open the project. Press F5 to run locally.

```bash
dotnet restore
dotnet run
```

Then open the URL shown in the console, e.g. `https://localhost:5001`.

> Note: this environment doesn't have the .NET SDK installed, so these files
> haven't been compiled here — build locally before you deploy to catch any
> typos.

## Deploying for free

There's no database here, so deployment is as simple as it gets — just the
compiled app, nothing to persist between deploys.

**Recommended: Azure App Service (Free F1 tier)** — native ASP.NET Core
support (no Docker required), a clean URL like `yourname.azurewebsites.net`.

1. Create a free Azure account (no charge on the F1 tier — a payment method
   is required for identity verification, but you won't be billed as long
   as you stay on F1 and add no paid resources).
2. Deploy with the Azure CLI:
   ```bash
   az webapp up --name your-app-name --runtime "DOTNETCORE:8.0" --sku F1
   ```
3. In **Configuration → General settings**, confirm **HTTPS Only** is on.
4. For continuous deployment on every push, connect the repo in the Azure
   Portal's **Deployment Center**.

**Alternative: Render.com** — uses the included `Dockerfile`, doesn't require
a card, auto-deploys on push. Since there's no database to worry about
persisting, Render's ephemeral filesystem isn't a concern here.

Either way, the security headers and HTTPS redirection in `Program.cs` work
the same regardless of host.

## OWASP Top 10 (2021) — what's implemented and where

Even a static-content site benefits from these — mostly headers and
configuration, not fancy code.

| Risk | Mitigation | Where |
|---|---|---|
| A01 Broken Access Control | No admin routes, no user input, nothing to gate access to | — |
| A02 Cryptographic Failures | HTTPS enforced site-wide, HSTS enabled in production | `Program.cs` |
| A03 Injection | No database, no raw SQL, no dynamic queries. Razor auto-encodes all output | `Program.cs` |
| A04 Insecure Design | Per-IP rate limiting on every request; request body/header size limits at the Kestrel level | `Program.cs` |
| A05 Security Misconfiguration | Strict CSP with no `unsafe-inline`, `X-Frame-Options`, `X-Content-Type-Options`, `Server` header removed, generic error pages (no stack traces) in production | `Program.cs`, `Pages/Error.cshtml` |
| A06 Vulnerable/Outdated Components | Zero external NuGet dependencies — nothing to have vulnerabilities in the first place | `Portfolio.csproj` |
| A07 Identification & Authentication Failures | No authentication exists on this site — nothing to compromise | — |
| A08 Software & Data Integrity Failures | No script/style loaded from a third-party CDN — everything same-origin, including the résumé PDF viewer | `Pages/Shared/_Layout.cshtml`, `Pages/Resume.cshtml` |
| A09 Security Logging & Monitoring Failures | Standard ASP.NET Core request logging via `ILogger` | built-in |
| A10 Server-Side Request Forgery | No outbound HTTP requests made from server code — nothing to forge | — |

## If you want a blog later

This was deliberately cut to keep the site simple and maintenance-free. If
you start writing regularly and want to add one back — with an in-browser
editor restricted to just you, backed by a small database — that's a clean
addition to bolt on later rather than something you need to design in from
day one.
