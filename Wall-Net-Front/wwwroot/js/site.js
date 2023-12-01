// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.isPrerendering = false;
window.addEventListener('DOMContentLoaded', function () {
    window.isPrerendering = false;
});



//btn-Scroll-To-Top
window.onscroll = function () {
    toggleScrollToTopButton();
};

function toggleScrollToTopButton() {
    var button = document.querySelector('.scroll-to-top')
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        button.style.opacity = '1';
    } else {
        button.style.opacity = '0';
    }
}
function scrollToTop() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}

