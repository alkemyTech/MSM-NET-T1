
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Session;
using System.IdentityModel.Tokens.Jwt;
using Wall_Net_Front.Extensiones;
using Wall_Net_Front.Pages.Models;

namespace Wall_Net_Front.Pages
{
    public class LoginModel : PageModel
    {
        private AuthenticationStateProvider _autenticacionProvider { get; set; } = default!;
        private NavigationManager _navManager { get; set; } = default!;

        public LoginModel(AuthenticationStateProvider autenticacionProvider, NavigationManager navManager)
        {
            _autenticacionProvider = autenticacionProvider;
            _navManager = navManager;
        }

        public LoginDTO login = new LoginDTO();

        public void OnGet()
        {
        }

        public async Task OnPost()
        {
            string email = Request.Form["email"];
            string password = Request.Form["password"];

            login.Email = email;
            login.Password = password;

            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.PostAsJsonAsync("http://localhost:5270/api/Login", login);
                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();

                    var handler = new JwtSecurityTokenHandler();
                    var jwtSecurityToken = handler.ReadJwtToken(token);


                    var nameToken = jwtSecurityToken.Claims.First(claim => claim.Type == "nameid").Value;
                    var emailToken= jwtSecurityToken.Claims.First(claim => claim.Type == "email").Value;
                    var rolToken = jwtSecurityToken.Claims.First(claim => claim.Type == "role").Value;

                    var sesionUsuario = new SessionDTO();

                    sesionUsuario.Name = nameToken;
                    sesionUsuario.Email = emailToken;
                    sesionUsuario.Rol = rolToken;

                    var autenticacionExt = (AutenticacionExtencion) _autenticacionProvider;

                    autenticacionExt.ActualizarEstadoAutenticacion(sesionUsuario);
                    

                    _navManager.NavigateTo("/Index");
                   
                }
                else
                {
                    _navManager.NavigateTo("/Login");
                }

            }
        }

    }
}
