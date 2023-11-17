using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Wall_Net.Models;

namespace Wall_Net.Models
{
    public class FixedTermDeposit
    {
        [Key]
        public int Id {  get; set; }

        public int UserId {  get; set; }

        [ForeignKey("UserId")] 
        public virtual User User { get; set; }

        public int AccountId { get; set; }

        [ForeignKey("AccountId")] 
        public virtual Account Account { get; set; }

        //////

        [RegularExpression("([1-9][0-9]*)", ErrorMessage ="Se solicita monto para iniciar el plazo fijo")]
        public decimal amount {  get; set; }

        [Range(typeof(DateTime), "0001-01-01", "closing_date", ErrorMessage = "Se solicita que ingrese una fecha para cerrar el plazo fijo")]
        public DateTime creation_date {  get; set; }

        [Range(typeof(DateTime), "creation_date", "9999-12-31",ErrorMessage ="Se solicita que ingrese una fecha para cerrar el plazo fijo")]
        public DateTime closing_date {  get; set; }

        [Range(5,20,ErrorMessage ="Por favor ingrese un numero valido")]
        public decimal nominalRate { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio.")]
        public string state {  get; set; }
    }
}
