using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wall_Net.Models;

namespace Wall_Net_Front.Pages.Users
{
    public class UserProfileModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public UserProfileModel()
        {
            _httpClient = new HttpClient();
        }

        [BindProperty]
        public User User { get; set; }
        public Account Account { get; set; }
        public FixedTermDeposit FixedTermDeposit { get; set; }
        public Transaction Transaction { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task<IActionResult> OnGetAsync(int Id = 1)
        {
            var userResponse = await _httpClient.GetAsync($"http://localhost:5270/api/User/{Id}");
            var accountResponse = await _httpClient.GetAsync($"http://localhost:5270/api/Accounts/{Id}");
            var fixedTermDepositResponse = await _httpClient.GetAsync($"http://localhost:5270/api/FixedTermDeposit/{Id}");
            var transactionResponse = await _httpClient.GetAsync($"http://localhost:5270/api/transactions/{Id}");

            if (userResponse.IsSuccessStatusCode && accountResponse.IsSuccessStatusCode && fixedTermDepositResponse.IsSuccessStatusCode && transactionResponse.IsSuccessStatusCode)
            {
                User = await userResponse.Content.ReadFromJsonAsync<User>();
                Account = await accountResponse.Content.ReadFromJsonAsync<Account>();
                FixedTermDeposit = await fixedTermDepositResponse.Content.ReadFromJsonAsync<FixedTermDeposit>();
                Transaction = await transactionResponse.Content.ReadFromJsonAsync<Transaction>();

                return Page();
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userResponse = await _httpClient.GetAsync($"http://localhost:5270/api/User/{User.Id}");

            var userToUpdate = await userResponse.Content.ReadFromJsonAsync<User>();

            userToUpdate.FirstName = User.FirstName;
            userToUpdate.LastName = User.LastName;

            var response = await _httpClient.PutAsJsonAsync($"http://localhost:5270/api/User/{User.Id}", userToUpdate);

            if (response.IsSuccessStatusCode)
            {
                Mensaje = "Campo editado correctamente";
                return RedirectToPage("UserProfile");
            }
            else
            {
                return Page();
            }
        }
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    //if (ModelState.IsValid == false)
        //    //{
        //    //    return Page();
        //    //}
        //    var updatedUser = new User
        //    {
        //        Id = User.Id,
        //        FirstName = User.FirstName,
        //        LastName = User.LastName,
        //        Email = User.Email,
        //        Password = User.Password,
        //        Points = User.Points,
        //        Rol_Id = User.Rol_Id,
        //    };

        //    var response = await _httpClient.PutAsJsonAsync($"http://localhost:5270/api/User/{User.Id}", updatedUser);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        Mensaje = "Campo editado correctamente";
        //        return RedirectToPage("UserProfile");
        //    }
        //    else
        //    {
        //        return Page();
        //    }
        //}
    }
}
