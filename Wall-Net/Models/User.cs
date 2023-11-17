using System.ComponentModel.DataAnnotations;

namespace Wall_Net.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Points { get; set; }
        public int Rol_Id { get; set; }
    }
}
