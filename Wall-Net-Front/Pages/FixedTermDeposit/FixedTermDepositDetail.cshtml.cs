using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using Wall_Net_Front.Pages.Models;

namespace Wall_Net_Front.Pages.FixedTermDeposit
{
    public class FixedTermDepositDetailModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public FixedTermDepositsModel fixedTerm { get; set; }
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FixedTermDepositDetailModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task OnGet(int Id)
        {
            using (var httpClient = new HttpClient())
            {
                var token = _httpContextAccessor.HttpContext.Session.GetString("NewSession");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await httpClient.GetAsync($"http://localhost:5270/api/FixedTermDeposit/{Id}");

                if (response.IsSuccessStatusCode)
                {
                    fixedTerm = await response.Content.ReadFromJsonAsync<FixedTermDepositsModel>();
                }
                else
                {
                    fixedTerm = new FixedTermDepositsModel();
                }
            }
        }
    }
}
