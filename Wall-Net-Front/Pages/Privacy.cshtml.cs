using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using Wall_Net_Front.Pages;

namespace Wall_Net_Front.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PrivacyModel(ILogger<PrivacyModel> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {
            using (var httpClient = new HttpClient())
            {
                string sessionToken = _httpContextAccessor.HttpContext.Session.GetString("NewSession");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionToken);

                // Simplificar la lógica de asignación de token
                bool token = sessionToken != null;

                ViewData["token"] = token;
            }
        }
    }
}




