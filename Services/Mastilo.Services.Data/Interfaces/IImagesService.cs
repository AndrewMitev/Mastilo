namespace Mastilo.Services.Data.Interfaces
{
    using Mastilo.Data.Models;

    public interface IImagesService
    {
        Image GetById(int id);

        int SaveNewImage(Image image);
    }
}
