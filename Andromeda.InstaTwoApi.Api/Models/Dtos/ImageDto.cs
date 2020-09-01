using System;

namespace Andromeda.InstaTwoApi.Api.Models.Dtos
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostedOn { get; set; }
        public string User { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}