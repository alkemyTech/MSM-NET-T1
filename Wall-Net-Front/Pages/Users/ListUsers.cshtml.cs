using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Wall_Net.Models;

namespace Wall_Net_Front.Pages.Users
{
    public class ListUsersModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ListUsersModel (IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<User> Users { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGetAsync(int pageNumber = 1, int pageSize = 10)
        {
            using (var httpClient = new HttpClient())
            {
                var token = _httpContextAccessor.HttpContext.Session.GetString("NewSession");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await httpClient.GetAsync($"http://localhost:5270/api/User?pageNumber={pageNumber}&pageSize={pageSize}");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    Users = JsonConvert.DeserializeObject<List<User>>(content);

                    TotalPages = Users.Count;//(int)Math.Ceiling((double)Users.Count / PageSize)
                    PageNumber = pageNumber;
                    PageSize = pageSize;
                }          
                else
                {
                    Users = new List<User>();
                }
            }
        }


        public async Task<IActionResult> OnPostBorrar(int Id)
        {
            using (var httpClient = new HttpClient())
            {
                var token = _httpContextAccessor.HttpContext.Session.GetString("NewSession");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await httpClient.DeleteAsync($"http://localhost:5270/api/User/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    Mensaje = "Usuario eliminado correctamente";
                    return RedirectToPage("ListUsers");
                }
                else
                {
                    return Page();
                }
            }
        }
    }
}
