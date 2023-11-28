using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Net.Http;
using Wall_Net.Models;
using System.Security.Claims;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Wall_Net_Front.Pages.Models;

namespace Wall_Net_Front.Pages.Users
{
    public class UserProfileModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpClient _httpClient;

        public UserProfileModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClient = new HttpClient();
        }


        [BindProperty]
        public User User { get; set; }
        public Account Account { get; set; }
        //public List<Wall_Net.Models.FixedTermDeposit> FixedTermDeposit { get; set; }
        //public List<Transaction> Transaction { get; set; }


        [TempData]
        public string Mensaje { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("NewSession");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Obtener el ID de usuario actual desde Get() de LoginControllers
            var currentUserIdResponse = await _httpClient.GetAsync("http://localhost:5270/api/Login");
            if (currentUserIdResponse.IsSuccessStatusCode)
            {
                var responseContent = await currentUserIdResponse.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(responseContent);
                var userId = jsonObject["id"].Value<int>();

                if (userId != null)
                {
                    var userResponse = await _httpClient.GetAsync($"http://localhost:5270/api/User/{userId}");
                    var accountResponse = await _httpClient.GetAsync($"http://localhost:5270/api/Accounts/{userId}");
                    //var fixedTermDepositResponse = await _httpClient.GetAsync($"http://localhost:5270/api/FixedTermDeposit/FixedTermDeposit/AllFixed");
                    //var transactionResponse = await _httpClient.GetAsync($"http://localhost:5270/api/Transactions/Transaction/AllTransaction");

                    if (userResponse.IsSuccessStatusCode && accountResponse.IsSuccessStatusCode /*&&
                        fixedTermDepositResponse.IsSuccessStatusCode && transactionResponse.IsSuccessStatusCode*/)
                    {
                        User = await userResponse.Content.ReadFromJsonAsync<User>();
                        Account = await accountResponse.Content.ReadFromJsonAsync<Account>();
                        //FixedTermDeposit = await fixedTermDepositResponse.Content.ReadFromJsonAsync<List<Wall_Net.Models.FixedTermDeposit>>();
                        //Transaction = await transactionResponse.Content.ReadFromJsonAsync<List<Transaction>>();

                        return Page();
                    }
                }
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostEditarAsync()
        {
            if (ModelState.IsValid == false)
            {
                var token = _httpContextAccessor.HttpContext.Session.GetString("NewSession");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var userResponse = await _httpClient.GetAsync($"http://localhost:5270/api/User/{User.Id}");

                if (userResponse.IsSuccessStatusCode)
                {
                    var userToUpdate = await userResponse.Content.ReadFromJsonAsync<User>();

                    User.Email = userToUpdate.Email;
                    User.Points = userToUpdate.Points;
                    userToUpdate.FirstName = User.FirstName;
                    userToUpdate.LastName = User.LastName;

                    var response = await _httpClient.PutAsJsonAsync($"http://localhost:5270/api/User/{User.Id}", userToUpdate);

                    if (response.IsSuccessStatusCode)
                    {
                        Mensaje = "Usuario editado correctamente";
                        return RedirectToPage("UserProfile");
                    }
                }
            }

            return Page();
        }
    }
}
