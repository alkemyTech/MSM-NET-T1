using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wall_Net.Models
{
    public class Account
    {
        [Key]
        public int id { get; set; }
        public DateTime creationDate { get; set; }
        public decimal money { get; set; }
        public bool isBlocked { get; set; }
        public int user_Id { get; set; }
        //[ForeignKey("user_Id")]
        //public virtual Account User { get; set; }
    }
}
