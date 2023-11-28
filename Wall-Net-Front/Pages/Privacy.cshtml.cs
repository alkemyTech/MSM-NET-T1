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

        public IActionResult OnGet()
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
                return Page();
            }
        }
    }
}




