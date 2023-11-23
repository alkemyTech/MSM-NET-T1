using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wall_Net_Front.Pages.Models;

namespace Wall_Net_Front.Pages.Transactions
{
    public class TransactionModel : PageModel
    {
        public List<TransactionsModel> transactionList { get; set; }

        [BindProperty]
        public TransactionsModel transaction { get; set; }

        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5270/api/transactions\r\n");

                if (response.IsSuccessStatusCode)
                {
                    transactionList = await response.Content.ReadFromJsonAsync<List<TransactionsModel>>();
                }
                else
                {
                    transactionList = new List<TransactionsModel>();
                }
            }
        }
    }
}
