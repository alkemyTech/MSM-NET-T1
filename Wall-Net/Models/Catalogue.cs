using System.ComponentModel.DataAnnotations;

namespace Wall_Net.Models
{
    public class Catalogue
    {
        [Key]
        public int Id { get; set; } // Id del producto

        
        [MaxLength(200)]
        public string ProductDescription { get; set; } // Descripcion del producto

        
        public string Image { get; set; } // imagen

        
        public decimal Points { get; set; } // puntos
    }
}