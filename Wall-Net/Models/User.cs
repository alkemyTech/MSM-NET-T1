using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Wall_Net.Models.DTO;

namespace Wall_Net.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Points { get; set; }
        public int Rol_Id { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<FixedTermDeposit> FixedTermDeposits { get; } = new List<FixedTermDeposit>();
        //public virtual Account account { get; set; } = null;
    }
}
