(function () {
    "use strict";

    const defaultTheme = "dark";

    try {
        const storedTheme =
            localStorage.getItem("theme");

        const prefersLightTheme =
            window.matchMedia &&
            window.matchMedia(
                "(prefers-color-scheme: light)"
            ).matches;

        const theme =
            storedTheme === "light" ||
                storedTheme === "dark"
                ? storedTheme
                : prefersLightTheme
                    ? "light"
                    : defaultTheme;

        document.documentElement.setAttribute(
            "data-theme",
            theme
        );
    } catch {
        document.documentElement.setAttribute(
            "data-theme",
            defaultTheme
        );
    }
})();