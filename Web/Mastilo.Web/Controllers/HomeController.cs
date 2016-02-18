namespace Mastilo.Web.Controllers
{
    using Data.Models;
    using Mastilo.Web.Infrastructure.Mapping;
    using Mastilo.Web.ViewModels.Jokes;
    using Services.Data.Interaces;
    using Services.Data.Interfaces;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        private IJokesService jokesService;
        private IImagesService imagesService;

        public HomeController(IJokesService jokesService, IImagesService imagesService)
        {
            this.jokesService = jokesService;
            this.imagesService = imagesService;
        }

        [HttpPost]
        public ActionResult UploadImage()
        {
            var image = this.Request.Files[0];

            if (image == null || image.ContentLength == 0)
            {
                return this.RedirectToAction("Index"); //TODO: Fix!
            }

            byte[] imageData = null;
            using (var binaryReader = new BinaryReader(image.InputStream))
            {
                imageData = binaryReader.ReadBytes(image.ContentLength);
            }
            var headerImage = new Image
            {
                ImageData = imageData,
                ImageName = image.FileName,
                IsActive = true
            };

            this.imagesService.SaveImage(headerImage);

            return this.RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var jokes = this.Cache.Get("jokes", () => jokesService.All().To<JokeViewModel>().ToList(), 3 * 60);
            return View(jokes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}