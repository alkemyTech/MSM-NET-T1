const toggles = document.querySelectorAll('.faq-toggle')

toggles.forEach(toggle => {
    toggle.addEventListener('click', (event) => {
        event.preventDefault(); // Evita la recarga de p�gina al hacer clic en el bot�n
        toggle.parentNode.classList.toggle('active')
    })
})