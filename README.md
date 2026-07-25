# Portfolio — ASP.NET Core

My personal portfolio: About, Experience, and a viewable +
downloadable resume. No database, no login, no user input anywhere — the
simplest architecture that still looks and feels like a real, professional
site..

## What's on the site

- **About** (`/`) — bio, skills, education, resume link, LinkedIn/Instagram/email
- **Experience** (`/Experience`) — a timeline of roles pulled from the resume,
  each with the project worked on, a plain-language description, tech tags,
  and a link to the company's public website
- **Resume** (`/Resume`) — the resume PDF viewable inline (via `<iframe>`,
  same-origin, no `object-src` exception needed) plus a direct download button

## Already filled in

- `Pages/Index.cshtml` — name, role, bio, skills, education (from the resume)
- `Pages/Experience.cshtml.cs` — all 5 roles from the resume, with company
  links verified against each company's real public site
- `wwwroot/resume/resume.pdf` — the actual resume

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
