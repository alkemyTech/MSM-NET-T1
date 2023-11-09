using System.ComponentModel.DataAnnotations;

namespace Wall_Net.Models
{
    public class Roles
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}