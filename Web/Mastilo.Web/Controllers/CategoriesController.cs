namespace Mastilo.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Services.Data.Interfaces;
    using ViewModels.GenreViewModels;

    [Authorize]
    public class CategoriesController : BaseController
    {
        private readonly IGenresService genresService;

        public CategoriesController(IGenresService genresService)
        {
            this.genresService = genresService;
        }

        public ActionResult GetCategoriesByGenreId(string id)
        {
            var genre = this.genresService.GetById(int.Parse(id));
            var viewModel = this.Mapper.Map<GenreViewModel>(genre);
            var categories = viewModel.Categories.ToList();

            return this.PartialView("_GetCategoriesByGenreIdPartial", categories);
        }
    }
}