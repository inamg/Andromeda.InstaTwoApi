using System;
using System.ComponentModel.DataAnnotations;

namespace Andromeda.InstaTwoApi.Data.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        
        [Required]
        public DateTime PostedOn { get; set; }
        
        public string Url { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}