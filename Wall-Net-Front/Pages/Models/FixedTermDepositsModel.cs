using System.ComponentModel.DataAnnotations;

namespace Wall_Net_Front.Pages.Models
{
    public class FixedTermDepositsModel
    {
        [Key]
        public int Id { get; set; }
        public decimal amount { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime closing_date { get; set; }
        public decimal? nominalRate { get; set; }
        public string? state { get; set; }
    }
}
