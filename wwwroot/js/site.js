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

    var scrollTopButton = document.getElementById('scroll-top');
    var scrollBottomButton = document.getElementById('scroll-bottom');

    function updateScrollControls() {
        if (!scrollTopButton && !scrollBottomButton) {
            return;
        }

        var scrollTop = window.scrollY || document.documentElement.scrollTop;
        var viewportHeight = window.innerHeight;
        var documentHeight = document.documentElement.scrollHeight;

        var nearTop = scrollTop < 120;
        var nearBottom = scrollTop + viewportHeight >= documentHeight - 120;

        if (scrollTopButton) {
            scrollTopButton.classList.toggle('is-hidden', nearTop);
        }

        if (scrollBottomButton) {
            scrollBottomButton.classList.toggle('is-hidden', nearBottom);
        }
    }

    if (scrollTopButton) {
        scrollTopButton.addEventListener('click', function () {
            window.scrollTo({
                top: 0,
                behavior: 'smooth'
            });
        });
    }

    if (scrollBottomButton) {
        scrollBottomButton.addEventListener('click', function () {
            window.scrollTo({
                top: document.documentElement.scrollHeight,
                behavior: 'smooth'
            });
        });
    }

    if (scrollTopButton || scrollBottomButton) {
        updateScrollControls();

        window.addEventListener(
            'scroll',
            updateScrollControls,
            { passive: true }
        );

        window.addEventListener(
            'resize',
            updateScrollControls
        );
    }
})();