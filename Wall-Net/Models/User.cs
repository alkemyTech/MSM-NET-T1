using Microsoft.AspNetCore.Mvc;
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
        public string Email { get; set; } = "lean@email.com";
        public string Password { get; set; } = "123456";
        public int Points { get; set; }
        public int Rol_Id { get; set; }

        public ICollection<FixedTermDeposit> FixedTermDeposit { get; set; } = null;
        public virtual Account account { get; set; } = null;
    }
}
