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

        [TempData]
        public string Mensaje { get; set; }

        public async Task<IActionResult> OnGetAsync(int Id = 1)
        {
            var userResponse = await _httpClient.GetAsync($"http://localhost:5270/api/User/{Id}");
            var accountResponse = await _httpClient.GetAsync($"http://localhost:5270/api/Accounts/{Id}");

            if (userResponse.IsSuccessStatusCode && accountResponse.IsSuccessStatusCode)
            {
                User = await userResponse.Content.ReadFromJsonAsync<User>();
                // Leer la respuesta del endpoint de cuentas si es necesario
                Account = await accountResponse.Content.ReadFromJsonAsync<Account>();

                return Page();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
