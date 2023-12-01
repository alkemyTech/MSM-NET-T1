﻿
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Wall_Net.Models.DTO;

namespace Wall_Net_Front.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IndexModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpContextAccessor.HttpContext.Session.Clear();
        }

        public string AuthToken { get; set; }

        [BindProperty]
        public LoginUser Login { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                // Captura los valores de usuario y contraseña desde la solicitud POST
                //string email = Request.Form["email"];
                //string password = Request.Form["password"];

                //Console.WriteLine(email + " " + password);

                var data = new LoginUser
                {
                    Email = Login.Email,
                    Password = Login.Password
                };
                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient())
                {

                    var response = await httpClient.PostAsync("http://localhost:5270/api/Login", content);
                    if (response.IsSuccessStatusCode)
                    {
                        string authToken = await response.Content.ReadAsStringAsync();
                        TempData["authToken"] = authToken;
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
                        string sessionToken = authToken;
                        _httpContextAccessor.HttpContext.Session.SetString("NewSession", sessionToken);
                        Console.WriteLine("Token guardado en variable local: " + sessionToken);
                        return RedirectToPage("/Home");
                    }

                    else
                    {
                        ModelState.AddModelError(string.Empty, "Credenciales inválidas");
                        return Page();
                    }

                }
            }

        }

    }
}
