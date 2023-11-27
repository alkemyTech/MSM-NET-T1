using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using Wall_Net_Front.Pages.Models;

namespace Wall_Net_Front.Pages.Catalogues
{
    public class CatalogueModel : PageModel
    {

        public List<CataloguesModel> catalogueList { get; set; }

        [BindProperty]
        public CataloguesModel catalogue { get; set; }

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CatalogueModel(IHttpContextAccessor httpContextAccessor)
        {
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
                    var response = await httpClient.GetAsync("http://localhost:5270/api/catalogue\r\n");

                    if (response.IsSuccessStatusCode)
                    {
                        catalogueList = await response.Content.ReadFromJsonAsync<List<CataloguesModel>>();
                    }
                    else
                    {
                        catalogueList = new List<CataloguesModel>();
                    }
                }
               return Page();
            }
        }

    }
}
