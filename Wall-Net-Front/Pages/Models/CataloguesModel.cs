using System.ComponentModel.DataAnnotations;

namespace Wall_Net_Front.Pages.Models
{
    public class CataloguesModel
    {
        [Key] 
        public int Id { get; set; }

        [MaxLength(200)]
        public string ProductDescription { get; set; }

        public string Image { get; set; }

        public decimal Points { get; set; }
    }
}
