// theme-toggle.js
(function () {
    const themeToggle = document.getElementById('theme-toggle');
    const html = document.documentElement;
    const lightIcon = document.getElementById('theme-toggle-light-icon');
    const darkIcon = document.getElementById('theme-toggle-dark-icon');

    function updateIcons() {
        const isDark = html.classList.contains('dark');
        if (isDark) {
            lightIcon.classList.remove('hidden');
            darkIcon.classList.add('hidden');
        } else {
            lightIcon.classList.add('hidden');
            darkIcon.classList.remove('hidden');
        }
    }

    function setTheme(dark) {
        if (dark) {
            html.classList.add('dark');
            html.setAttribute('data-theme', 'dark');
            localStorage.setItem('theme', 'dark');
        } else {
            html.classList.remove('dark');
            html.setAttribute('data-theme', 'light');
            localStorage.setItem('theme', 'light');
        }
        updateIcons();
    }

    // Initial theme: only use localStorage, ignore system preference
    const userTheme = localStorage.getItem('theme');
    if (userTheme === 'dark') {
        html.classList.add('dark');
        html.setAttribute('data-theme', 'dark');
    } else {
        html.classList.remove('dark');
        html.setAttribute('data-theme', 'light');
    }
    updateIcons();

    themeToggle && themeToggle.addEventListener('click', function () {
        setTheme(!html.classList.contains('dark'));
    });

    // Keep icons in sync if class changes elsewhere
    const observer = new MutationObserver(updateIcons);
    observer.observe(html, { attributes: true, attributeFilter: ['class'] });
})(); 