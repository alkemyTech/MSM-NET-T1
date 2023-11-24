using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;

namespace Wall_Net_Front.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IndexModel(ILogger<IndexModel> logger, IHttpContextAccessor httpContextAccessor)
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
                bool token = sessionToken != null;
                ViewData["token"] = token;
            }
        }

    }
}