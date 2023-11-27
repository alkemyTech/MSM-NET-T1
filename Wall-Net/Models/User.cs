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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
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
