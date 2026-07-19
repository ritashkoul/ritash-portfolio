(function () {
    try {
        var stored = localStorage.getItem('theme');
        var theme = stored === 'light' || stored === 'dark'
            ? stored
            : (window.matchMedia && window.matchMedia('(prefers-color-scheme: light)').matches ? 'light' : 'dark');
        document.documentElement.setAttribute('data-theme', theme);
    } catch (e) {
        // localStorage can throw in some privacy modes - fall back to dark, matches the default tokens
        document.documentElement.setAttribute('data-theme', 'dark');
    }
})();
