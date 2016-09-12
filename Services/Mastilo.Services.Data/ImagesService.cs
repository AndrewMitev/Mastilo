namespace Mastilo.Services.Data
{
    using Mastilo.Data.Common;
    using Mastilo.Data.Models;
    using Mastilo.Services.Data.Interfaces;

    public class ImagesService : IImagesService
    {
        private readonly IDbRepository<Image> images;

        public ImagesService(IDbRepository<Image> _images)
        {
            this.images = _images;
        }

        public Image GetById(int id)
        {
            return this.images.GetById(id);
        }

        public int SaveNewImage(Image image)
        {
            this.images.Add(image);

            this.images.Save();

            return image.Id;
        }
    }
}
