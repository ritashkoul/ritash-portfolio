# Portfolio — ASP.NET Core

My portfolio: About, Experience, and a viewable +
downloadable resume. No database, no login, no user input anywhere — the
simplest architecture that still looks and feels like a real, professional
site..

## What's on the site

- **About** (`/`) — bio, skills, education, resume link, LinkedIn/Instagram/Email
- **Experience** (`/Experience`) — a timeline of roles pulled from the resume,
  each with the project worked on, a plain-language description, tech tags,
  and a link to the company's public website
- **Resume** (`/Resume`) — the resume PDF viewable inline (via `<iframe>`,
  same-origin, no `object-src` exception needed) plus a direct download button

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

Create a free Azure account (no charge on the F1 tier — a payment method
is required for identity verification, but you won't be billed as long
as you stay on F1 and add no paid resources).

**Alternative: Render.com** — uses the included `Dockerfile`, doesn't require
a card, auto-deploys on push. Since there's no database to worry about
persisting, Render's filesystem isn't a concern here.
