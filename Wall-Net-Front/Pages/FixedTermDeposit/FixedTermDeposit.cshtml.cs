using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using Wall_Net_Front.Pages.Models;

namespace Wall_Net_Front.Pages.FixedTermDeposit
{
    public class FixedTermDepositModel : PageModel
    {
        public List<FixedTermDepositsModel> FixedTermList { get; set; }

        [BindProperty]
        public FixedTermDepositsModel FixedTerm { get; set; }
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FixedTermDepositModel(IHttpContextAccessor httpContextAccessor)
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
                    var token = _httpContextAccessor.HttpContext.Session.GetString("NewSession");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var response = await httpClient.GetAsync("http://localhost:5270/api/FixedTermDeposit/FixedTermDeposit/AllFixed");

                    if (response.IsSuccessStatusCode)
                    {
                        FixedTermList = await response.Content.ReadFromJsonAsync<List<FixedTermDepositsModel>>();
                    }
                    else
                    {
                        FixedTermList = new List<FixedTermDepositsModel>();
                    }
                }
                return Page();
            }
        }


        public async Task<IActionResult> OnPostPut(int Id)
        {
            var data = new
            {
                idFixed = Id

            };

            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {

                var token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJCcnVubyIsImVtYWlsIjoiYnJ1bm9AZW1haWwuY29tIiwiZ2l2ZW5fbmFtZSI6IkJydW5vIiwiZmFtaWx5X25hbWUiOiJBdmlsYSIsInJvbGUiOiJSZWd1bGFyIiwiUG9pbnRzIjoiMTAyMCwwMCIsIklkIjoiMTYiLCJuYmYiOjE3MDA3NTQyOTgsImV4cCI6MTcwMDc1NDg5OCwiaWF0IjoxNzAwNzU0Mjk4LCJpc3MiOiJXYWxsTmV0IiwiYXVkIjoiV2FsbE5ldERldiJ9.ILbHpgmE-boiWZ8yUXgHpE5ZKQxYupHA1D_gt4L-V8O9zlcNpCwmzmDl9XEdEyKgUOlrm3Je1r88-nF5HvM-5g";
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await httpClient.PutAsync($"http://localhost:5270/api/FixedTermDeposit/{Id}",null);

                if (response.IsSuccessStatusCode)
                {
                    await OnGetAsync();
                    return Page();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Este plazo fijo ya fue cerrado");
                    await OnGetAsync();
                    return Page();
                }
            }
        }
    }
}
