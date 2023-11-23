using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wall_Net_Front.Pages.Models;

namespace Wall_Net_Front.Pages.FixedTermDeposit
{
    public class FixedTermDepositModel : PageModel
    {
        public List<FixedTermDepositsModel> FixedTermList { get; set; }

        [BindProperty]
        public FixedTermDepositsModel FixedTerm { get; set; }

        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5270/api/FixedTermDeposit\r\n");

                if (response.IsSuccessStatusCode)
                {
                    FixedTermList= await response.Content.ReadFromJsonAsync<List<FixedTermDepositsModel>>();
                }
                else
                {
                    FixedTermList = new List<FixedTermDepositsModel>();
                }
            }
        }
    }
}
