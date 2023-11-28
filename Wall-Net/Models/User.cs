using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wall_Net.Models.DTO;

namespace Wall_Net.Models
{
    public class User
    {
        [Key]
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

        public decimal Points { get; set; }

        public int Rol_Id { get; set; }

        public int AccountId { get; set; }


        [ForeignKey("AccountId")]
        [JsonIgnore]
        public virtual Account? Account { get; set; }

        [JsonIgnore]
        [InverseProperty("User")]
        public virtual ICollection<FixedTermDeposit> FixedTermDeposits { get; } = new List<FixedTermDeposit>();

        [JsonIgnore]
        [InverseProperty("User")]
        public virtual ICollection<Account>? Accounts { get; set; } = new List<Account>();
    }
}
