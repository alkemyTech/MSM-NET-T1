using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wall_Net_Front.Pages.Models;

namespace Wall_Net_Front.Pages.Catalogues
{
    public class CatalogueDetailModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CatalogueDetailModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public CataloguesModel catalogue { get; set; }
        public async Task<IActionResult> OnGetAsync(int Id)
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
                    var response = await httpClient.GetAsync($"http://localhost:5270/api/catalogue/{Id}");

                    if (response.IsSuccessStatusCode)
                    {
                        catalogue = await response.Content.ReadFromJsonAsync<CataloguesModel>();
                    }
                    else
                    {
                        catalogue = new CataloguesModel();
                    }
                }
                return Page();
            }
        }

    }
}
