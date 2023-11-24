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
                var token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJCcnVubyIsImVtYWlsIjoiYnJ1bm9AZW1haWwuY29tIiwiZ2l2ZW5fbmFtZSI6IkJydW5vIiwiZmFtaWx5X25hbWUiOiJBdmlsYSIsInJvbGUiOiJSZWd1bGFyIiwiUG9pbnRzIjoiMTAyMCwwMCIsIklkIjoiMTYiLCJuYmYiOjE3MDA3NTQyOTgsImV4cCI6MTcwMDc1NDg5OCwiaWF0IjoxNzAwNzU0Mjk4LCJpc3MiOiJXYWxsTmV0IiwiYXVkIjoiV2FsbE5ldERldiJ9.ILbHpgmE-boiWZ8yUXgHpE5ZKQxYupHA1D_gt4L-V8O9zlcNpCwmzmDl9XEdEyKgUOlrm3Je1r88-nF5HvM-5g";
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
