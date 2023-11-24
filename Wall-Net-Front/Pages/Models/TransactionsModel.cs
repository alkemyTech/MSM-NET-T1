using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Wall_Net_Front.Pages.Models
{
    public class TransactionsModel
    {
        [Key]
        public int TransactionId { get; set; } // Id de transacción

        public decimal Amount { get; set; } // Monto

        public string Concept { get; set; } // Observación

        public DateTime Date { get; set; } // Fecha

        public string Type { get; set; } // tipo de transacción - debe ser 'topup' o 'payment'

        public int AccountId { get; set; } // Id de cuenta

        public int UserId { get; set; } // Id de usuario
        public int? ToAccountId { get; set; }
    }
}
