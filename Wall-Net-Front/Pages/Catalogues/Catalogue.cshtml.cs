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

        public async Task OnGetAsync()
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
        }
        //public async Task OnPostFormulario(int id, string image)
        //{
        //    return RedirectToAction("Destino", new { Campo1 = id, Campo2 = image});
        //}

    }
}
