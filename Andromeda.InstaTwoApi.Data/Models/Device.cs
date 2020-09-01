using System.ComponentModel.DataAnnotations;

namespace Andromeda.InstaTwoApi.Data.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; } // 
        
        [Required]
        public string Name { get; set; }
    }
}