using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Andromeda.InstaTwoApi.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public IEnumerable<Image> UserImages { get; set; }
        
        public IEnumerable<Device> UserDevices { get; set; }
    }
}