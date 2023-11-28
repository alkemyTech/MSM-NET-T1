using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using Wall_Net_Front.Pages.Models;

namespace Wall_Net_Front.Pages.Transactions
{
    public class TransactionModel : PageModel
    {
        public List<TransactionsModel> transactionList { get; set; }
        private readonly IHttpContextAccessor _httpContextAccessor;

        [BindProperty]
        public TransactionsModel transaction { get; set; }

        public TransactionModel(IHttpContextAccessor httpContextAccessor)
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

                    var response = await httpClient.GetAsync("http://localhost:5270/api/Transactions/Transaction/AllTransaction");

                    if (response.IsSuccessStatusCode)
                    {
                        transactionList = await response.Content.ReadFromJsonAsync<List<TransactionsModel>>();
                    }
                    else
                    {
                        transactionList = new List<TransactionsModel>();
                    }
                }
                return Page();
            }
        }
    }
}
