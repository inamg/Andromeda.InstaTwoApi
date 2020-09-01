using System;

namespace Andromeda.InstaTwoApi.Api.Models.ViewModels
{
    public class ImageViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostedOn { get; set; } = DateTime.Now;
        public string User { get; set; }
        public string Url { get; set; }
    }
}