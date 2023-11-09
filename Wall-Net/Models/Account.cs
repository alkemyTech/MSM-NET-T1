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
        //[ForeignKey("user_Id")]
        //public virtual Account User { get; set; }
    }
}
