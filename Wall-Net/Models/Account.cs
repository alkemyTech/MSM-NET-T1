using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Wall_Net.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Money { get; set; }
        public bool IsBlocked { get; set; }
        
        public int UserId { get; set; }
        /*[ForeignKey("UserId")]
        public virtual User User { get; set; }*/

        [ForeignKey("UserId")]
        [JsonIgnore]
        public virtual User? User { get; set; }

        [JsonIgnore]
        [InverseProperty("Account")]
        public virtual ICollection<FixedTermDeposit>? FixedTermDeposit { get; set; }
        [JsonIgnore]
        [InverseProperty("Account")]
        public virtual ICollection<Transaction>? Transactions { get; set; } = new List<Transaction>();
    }
}
