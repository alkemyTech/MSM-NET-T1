using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Wall_Net_Front.Pages
{
    public class LoginModel : PageModel
    {
        public string AuthToken { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            // Captura los valores de usuario y contraseña desde la solicitud POST
            string email = Request.Form["email"];
            string password = Request.Form["password"];

            Console.WriteLine(email + " " + password);

            var data = new
            {
                email = email,
                password = password
            };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.PostAsync("http://localhost:5270/api/Login", content);
                if (response.IsSuccessStatusCode)
                {
                    string AuthToken = await response.Content.ReadAsStringAsync();
                    TempData["authToken"] = AuthToken; // Guarda el token en ViewData
                    Console.WriteLine("Token generado y asignado: " + AuthToken); // Agrega esta línea para depurar
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);
                    return RedirectToPage("/Index");
                }
                else
                {
                    return Page();

                }

            }
        }


    }
}
