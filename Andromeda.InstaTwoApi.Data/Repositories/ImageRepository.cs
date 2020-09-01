using Andromeda.InstaTwoApi.Data.Models;

namespace Andromeda.InstaTwoApi.Data.Repositories
{
    public class ImageRepository : Repository<Image> , IImageRepository
    {
        private readonly InstaContext _instaContext;

        public ImageRepository(InstaContext instaContext) : base(instaContext)
        {
            _instaContext = instaContext;
        }
    }
}