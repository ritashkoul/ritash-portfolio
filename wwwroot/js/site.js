// Keep all JS in this file and referenced via <script src="...">. Never add
// inline <script> or onclick="" attributes - the Content-Security-Policy in
// Program.cs (script-src 'self') blocks them, which is intentional: it makes
// inline-script-injection XSS impossible.

(function () {
    "use strict";

    /* ============================================================
       Theme
       ============================================================ */

    var themeToggle = document.getElementById("theme-toggle");

    var THEME_COLORS = {
        dark: "#171b20",
        light: "#e9e6dd"
    };

    function getCurrentTheme() {
        return document.documentElement.getAttribute("data-theme") === "light"
            ? "light"
            : "dark";
    }

    function syncMetaThemeColor(theme) {
        var meta = document.getElementById("theme-color-meta");

        if (meta) {
            meta.setAttribute(
                "content",
                THEME_COLORS[theme] || THEME_COLORS.dark
            );
        }
    }

    syncMetaThemeColor(getCurrentTheme());

    if (themeToggle) {
        themeToggle.addEventListener("click", function () {
            var current = getCurrentTheme();
            var next = current === "light" ? "dark" : "light";

            document.documentElement.setAttribute(
                "data-theme",
                next
            );

            syncMetaThemeColor(next);

            try {
                localStorage.setItem("theme", next);
            } catch (e) {
                // Theme still works for the current browser session.
            }
        });
    }


    /* ============================================================
       Experience page scroll controls
       ============================================================ */

    var scrollTopButton =
        document.getElementById("scroll-top");

    var scrollBottomButton =
        document.getElementById("scroll-bottom");


    /*
       Other pages don't contain these controls.
       Stop here after initializing the theme.
    */
    if (!scrollTopButton && !scrollBottomButton) {
        return;
    }


    function getScrollTop() {
        return (
            window.pageYOffset ||
            document.documentElement.scrollTop ||
            document.body.scrollTop ||
            0
        );
    }


    function getDocumentHeight() {
        return Math.max(
            document.documentElement.scrollHeight,
            document.body.scrollHeight,
            document.documentElement.offsetHeight,
            document.body.offsetHeight,
            document.documentElement.clientHeight
        );
    }


    function updateScrollControls() {
        var scrollTop = getScrollTop();

        var viewportHeight =
            window.innerHeight ||
            document.documentElement.clientHeight;

        var documentHeight =
            getDocumentHeight();


        /*
           Hide UP when close to the top.
        */
        var nearTop =
            scrollTop <= 120;


        /*
           Hide DOWN when close to the bottom.
        */
        var nearBottom =
            scrollTop + viewportHeight >=
            documentHeight - 120;


        if (scrollTopButton) {
            scrollTopButton.classList.toggle(
                "is-hidden",
                nearTop
            );
        }


        if (scrollBottomButton) {
            scrollBottomButton.classList.toggle(
                "is-hidden",
                nearBottom
            );
        }
    }


    /* ============================================================
       Scroll to top
       ============================================================ */

    if (scrollTopButton) {
        scrollTopButton.addEventListener(
            "click",
            function () {
                window.scrollTo({
                    top: 0,
                    left: 0,
                    behavior: "smooth"
                });
            }
        );
    }


    /* ============================================================
       Scroll to bottom
       ============================================================ */

    if (scrollBottomButton) {
        scrollBottomButton.addEventListener(
            "click",
            function () {
                window.scrollTo({
                    top: getDocumentHeight(),
                    left: 0,
                    behavior: "smooth"
                });
            }
        );
    }


    /* ============================================================
       Keep button visibility in sync
       ============================================================ */

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


    /*
       Set the correct state as soon as
       the Experience page loads.
    */
    updateScrollControls();

})();