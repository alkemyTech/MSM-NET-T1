
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Wall_Net.Models;

namespace Wall_Net_Front.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RegisterModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;


            _httpContextAccessor.HttpContext.Session.Clear();

        }

        public User User { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            { 
                // Captura los valores de usuario y contraseña desde la solicitud POST
                string firstName = Request.Form["firstName"];
                string lastName = Request.Form["lastName"];
                string email = Request.Form["email"];
                string password = Request.Form["password"];

                Console.WriteLine(firstName + " " + lastName + " " + email + " " + password);

                var data = new
                {
                    firstName = firstName,
                    lastName = lastName,
                    email = email,
                    password = password
                };
                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        var response = await httpClient.PostAsync("http://localhost:5270/api/User", content);
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToPage("/Index");
                        }
                        else
                        {
                            return Page();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error during registration: " + ex.Message);
                        return Page();
                    }


                }

            }

        }
    }
}
