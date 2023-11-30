using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wall_Net.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; } // Id de transacción
        [Required(ErrorMessage = "El campo 'Amount' es obligatorio.")]
        public decimal Amount { get; set; } // Monto
        
        public string Concept { get; set; } // Observación
        
        public DateTime Date { get; set; } // Fecha
        
        public string Type { get; set; } // tipo de transacción - debe ser 'topup' o 'payment'

        public int AccountId { get; set; } // Id de cuenta
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        public int UserId { get; set; } // Id de usuario
        [ForeignKey("UserId")]
        public virtual User User { get; set; }


        public int? ToAccountId { get; set; }

    }
}
