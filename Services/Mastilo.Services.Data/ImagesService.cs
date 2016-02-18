namespace Mastilo.Services.Data
{
    using Mastilo.Data.Common;
    using Mastilo.Data.Models;
    using Mastilo.Services.Data.Interfaces;

    public class ImagesService : IImagesService
    {
        private IDbRepository<Image> images;

        public ImagesService(IDbRepository<Image> images)
        {
            this.images = images;
        }

        public bool SaveImage(Image image)
        {
            this.images.Add(image);

            this.images.Save();

            return true;
        }
    }
}
