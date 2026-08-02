(function () {
    "use strict";

    const themeToggle =
        document.getElementById("theme-toggle");

    const scrollTopButton =
        document.getElementById("scroll-top");

    const scrollBottomButton =
        document.getElementById("scroll-bottom");

    const themeColors = {
        dark: "#171b20",
        light: "#e9e6dd"
    };


    /* ============================================================
       Theme
       ============================================================ */

    function getCurrentTheme() {
        return document.documentElement
            .getAttribute("data-theme") === "light"
            ? "light"
            : "dark";
    }

    function updateThemeColor(theme) {
        const meta =
            document.getElementById(
                "theme-color-meta"
            );

        if (meta) {
            meta.setAttribute(
                "content",
                themeColors[theme]
            );
        }
    }

    function setTheme(theme) {
        document.documentElement.setAttribute(
            "data-theme",
            theme
        );

        updateThemeColor(theme);

        try {
            localStorage.setItem(
                "theme",
                theme
            );
        } catch {
            // Theme remains active for the current session.
        }
    }

    function toggleTheme() {
        const nextTheme =
            getCurrentTheme() === "light"
                ? "dark"
                : "light";

        setTheme(nextTheme);
    }

    updateThemeColor(
        getCurrentTheme()
    );

    themeToggle?.addEventListener(
        "click",
        toggleTheme
    );


    /* ============================================================
       Scroll controls
       ============================================================ */

    if (!scrollTopButton && !scrollBottomButton) {
        return;
    }

    function getDocumentHeight() {
        return Math.max(
            document.documentElement.scrollHeight,
            document.body.scrollHeight
        );
    }

    function updateScrollControls() {
        const scrollTop =
            window.scrollY ||
            document.documentElement.scrollTop;

        const viewportHeight =
            window.innerHeight;

        const documentHeight =
            getDocumentHeight();

        const nearTop =
            scrollTop <= 120;

        const nearBottom =
            scrollTop + viewportHeight >=
            documentHeight - 120;

        scrollTopButton?.classList.toggle(
            "is-hidden",
            nearTop
        );

        scrollBottomButton?.classList.toggle(
            "is-hidden",
            nearBottom
        );
    }

    scrollTopButton?.addEventListener(
        "click",
        function () {
            window.scrollTo({
                top: 0,
                behavior: "smooth"
            });
        }
    );

    scrollBottomButton?.addEventListener(
        "click",
        function () {
            window.scrollTo({
                top: getDocumentHeight(),
                behavior: "smooth"
            });
        }
    );

    window.addEventListener(
        "scroll",
        updateScrollControls,
        {
            passive: true
        }
    );

    window.addEventListener(
        "resize",
        updateScrollControls
    );

    updateScrollControls();
})();