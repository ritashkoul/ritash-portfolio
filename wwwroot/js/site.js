// Intentionally minimal. This site is server-rendered Razor Pages with no
// client-side state, no fetch() calls, and no DOM injection from user input -
// so there's very little for a script to safely do, and that's by design:
// fewer moving parts on the client means less surface for XSS to exploit.
//
// If you add interactive features later (a mobile nav toggle, a copy-to-
// clipboard button, etc.), keep all JS in this file and referenced via
// <script src="...">. Never add inline <script> or onclick="" attributes -
// the Content-Security-Policy in Program.cs (script-src 'self') blocks them,
// which is intentional: it makes inline-script-injection XSS impossible.
