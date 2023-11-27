const toggles = document.querySelectorAll('.faq-toggle')

toggles.forEach(toggle => {
    toggle.addEventListener('click', (event) => {
        event.preventDefault(); // Evita la recarga de página al hacer clic en el botón
        toggle.parentNode.classList.toggle('active')
    })
})