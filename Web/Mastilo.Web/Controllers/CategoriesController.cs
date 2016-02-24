namespace Mastilo.Web.Controllers
{
    using Services.Data.Interfaces;
    using System.Linq;
    using System.Web.Mvc;
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