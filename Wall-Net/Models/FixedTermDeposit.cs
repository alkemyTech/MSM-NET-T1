using System.ComponentModel.DataAnnotations;

namespace Wall_Net.Models
{
    public class FixedTermDeposit
    {
        [Key] public int Id {  get; set; }
        public int user_id {  get; set; }
        public int account_id { get; set; }
        public decimal amount {  get; set; }
        public DateTime creation_date {  get; set; }
        public DateTime closing_date {  get; set; }
        public decimal nominalRate {  get; set; }
        public string state {  get; set; }
    }
}
