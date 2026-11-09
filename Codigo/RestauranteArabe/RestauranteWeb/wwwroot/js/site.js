const toggle = document.querySelector("#menu-toggle");
const sidebar = document.querySelector("aside");

toggle.addEventListener("click", () => {
    sidebar.classList.toggle("active");
});
