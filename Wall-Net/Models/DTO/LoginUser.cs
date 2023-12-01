using System.ComponentModel.DataAnnotations;

namespace Wall_Net.Models.DTO
{
    public class LoginUser
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; }
    }
}
