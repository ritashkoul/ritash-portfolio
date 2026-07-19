// Keep all JS in this file and referenced via <script src="...">. Never add
// inline <script> or onclick="" attributes - the Content-Security-Policy in
// Program.cs (script-src 'self') blocks them, which is intentional: it makes
// inline-script-injection XSS impossible.

(function () {
    var toggle = document.getElementById('theme-toggle');
    if (!toggle) return;

    var THEME_COLORS = { dark: '#171b20', light: '#e9e6dd' };

    function syncMetaThemeColor(theme) {
        var meta = document.getElementById('theme-color-meta');
        if (meta) meta.setAttribute('content', THEME_COLORS[theme] || THEME_COLORS.dark);
    }

    // Reflect whatever theme-init.js already picked, before any click happens
    syncMetaThemeColor(document.documentElement.getAttribute('data-theme') === 'light' ? 'light' : 'dark');

    toggle.addEventListener('click', function () {
        var current = document.documentElement.getAttribute('data-theme') === 'light' ? 'light' : 'dark';
        var next = current === 'light' ? 'dark' : 'light';

        document.documentElement.setAttribute('data-theme', next);
        syncMetaThemeColor(next);

        try {
            localStorage.setItem('theme', next);
        } catch (e) {
            // Preference just won't persist across visits (e.g. private browsing) - not fatal
        }
    });
})();