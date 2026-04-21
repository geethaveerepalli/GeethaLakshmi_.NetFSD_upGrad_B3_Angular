const body = document.body;
const button = document.getElementById("toggleBtn");

function applyTheme(theme) {
    if (theme === "dark") {
        body.style.backgroundColor = "#121212";
        body.style.color = "#ffffff";
    } else {
        body.style.backgroundColor = "#ffffff";
        body.style.color = "#000000";
    }

    localStorage.setItem("theme", theme);
}

function toggleTheme() {
    const currentTheme = localStorage.getItem("theme") || "light";
    const newTheme = currentTheme === "dark" ? "light" : "dark";
    applyTheme(newTheme);
}

function loadTheme() {
    const savedTheme = localStorage.getItem("theme") || "light";
    applyTheme(savedTheme);
}

button.addEventListener("click", toggleTheme);

loadTheme();