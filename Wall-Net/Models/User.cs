using System.ComponentModel.DataAnnotations;

namespace Wall_Net.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es oblogatorio.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El campo Apellido es oblogatorio.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo Email es oblogatorio.")]
        [EmailAddress(ErrorMessage = "El campo Email no tiene un formato válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es oblogatorio.")]
        public string Password { get; set; }

        public int Points { get; set; }

        public int Rol_Id { get; set; }
    }
}
