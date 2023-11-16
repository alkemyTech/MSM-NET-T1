using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Wall_Net.Models
{
    [Bind]
    public class FixedTermDeposit
    {
        [Key,ScaffoldColumn(false)]
         public int Id {  get; set; }

        [DisplayName("User")]
        public int UserId {  get; set; }
        
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [DisplayName("Account")]
        public int AccountId { get; set; }
        
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        //////

        [RegularExpression("([1-9][0-9]*)", ErrorMessage ="Se solicita monto para iniciar el plazo fijo")]
        public decimal amount {  get; set; }

        public DateTime creation_date {  get; set; }

        [Range(typeof(DateTime),"now","9999-12-31",ErrorMessage ="Se solicita que ingrese una fecha para cerrar el plazo fijo")]
        public DateTime closing_date {  get; set; }

        [Range(5,20,ErrorMessage ="Por favor ingrese un numero valido")]
        public decimal nominalRate { get; set; } = 10;
        public string state {  get; set; }
    }
}
