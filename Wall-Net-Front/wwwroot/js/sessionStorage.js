window.addEventListener('load', () => {
    console.log("js session vinculado");

    // Obtén el token de sessionStorage
    var authToken = sessionStorage.getItem("AuthToken");

    switch (true) {
        case (!authToken && token !== null && token !== undefined):
            // Si no hay un token y 'token' está definido
            let authorizeToken = token.toString();

            // Asegúrate de que el token aún no se haya establecido en sessionStorage
            if (!sessionStorage.getItem("AuthToken")) {
                sessionStorage.setItem("AuthToken", authorizeToken);
                var authToken = sessionStorage.getItem("AuthToken");

                // Muestra "Cerrar Sesión" si el token no está vacío
                if (authToken && authToken.trim() !== "") {
                    mostrarCerrarSesion();
                } else {
                    mostrarIniciarSesion();
                }
            }
            break;

        case (!!authToken && authToken.trim() !== ""):
            // Si el token existe en sessionStorage y no está vacío, muestra "Cerrar Sesión"
            mostrarCerrarSesion();
            break;

        default:
            // Si el token ya existe en sessionStorage, no se recargará
            console.log("El token ya existe en sessionStorage, no se recargará");
            break;
    }
});

function mostrarCerrarSesion() {
    var contenido = document.getElementById('contenido');
    var botonSesion = document.getElementById('botonSesion');
    contenido.style.display = 'block';
    botonSesion.style.display = 'none';
}

function mostrarIniciarSesion() {
    var contenido = document.getElementById('contenido');
    var botonSesion = document.getElementById('botonSesion');
    contenido.style.display = 'none';
    botonSesion.style.display = 'block';
}

function cerrarSesion() {
    // Lógica para cerrar sesión, por ejemplo, limpiar sessionStorage y redirigir
    sessionStorage.removeItem("AuthToken");
    window.location.href = '/Index';
}

function iniciarSesion() {
    // Lógica para iniciar sesión, por ejemplo, redirigir a la página de inicio de sesión
    window.location.href = '/Login';
}
