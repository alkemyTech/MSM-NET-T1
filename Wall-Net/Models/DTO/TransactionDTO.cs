using System.ComponentModel.DataAnnotations;

namespace Wall_Net.Models.DTO
{
    public class TransactionDTO
    {
        [Key]
        public int TransactionId { get; set; } // Id de transacción

        public decimal Amount { get; set; } // Monto

        public string Concept { get; set; } // Observación

        public DateTime Date { get; set; } // Fecha

        public string Type { get; set; }
    }
}
