using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using System.Collections;
using Wall_Net_Front.Pages.Models;
using Newtonsoft.Json;
using Wall_Net.Models;

namespace Wall_Net_Front.Pages
{
    public class HomeModel : PageModel
    {
        private readonly ILogger<HomeModel> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeModel(ILogger<HomeModel> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            string sessionToken = _httpContextAccessor.HttpContext.Session.GetString("NewSession");
            bool tokenValidate = sessionToken != null;
            ViewData["token"] = tokenValidate;

            if (!tokenValidate)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionToken);

                    var response = await httpClient.GetAsync("http://localhost:5270/api/Login");

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var usuario = JsonConvert.DeserializeObject<User>(content);

                        // Pasa el objeto a la vista
                        ViewData["currentUser"] = usuario;
                    }
                    else
                    {
                        return StatusCode(400, new { message = "No se encontraron los Datos del Usuario" });
                    }
                }

                return Page();
            }
        }

        public class Claim
        {
            public string Type { get; set; }
            public string Value { get; set; }
        }


    }
}