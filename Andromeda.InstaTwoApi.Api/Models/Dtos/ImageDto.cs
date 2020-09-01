using System;

namespace Andromeda.InstaTwoApi.Api.Models.Dtos
{
    public class ImageDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostedOn { get; set; }
        public string User { get; set; }
    }
}