using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wall_Net.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Money { get; set; }
        public bool IsBlocked { get; set; }

        public int User_Id { get; set; }
        [ForeignKey("User_Id")]
        public virtual User User { get; set; }

        [InverseProperty("Account")]
        public virtual ICollection<FixedTermDeposit> FixedTermDeposit { get; set; }
    }
}
