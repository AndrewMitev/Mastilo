namespace Mastilo.Services.Data.Interfaces
{
    using Mastilo.Data.Models;

    public interface IImagesService
    {
        bool SaveImage(Image image);
    }
}
