namespace Mastilo.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data.Interfaces;
    using ViewModels.MasterpieceViewModels;

    public class ExploreController : BaseController
    {
        private readonly IMasterpiecesService masterpiecesService;

        public ExploreController(IMasterpiecesService masterpiecesService)
        {
            this.masterpiecesService = masterpiecesService;
        }

        public ActionResult Index()
        {
            var masterpieces = this.Cache.Get(
                "masterpieces",
                () => this.masterpiecesService.AllSortedByDate().To<MasterpieceResponseViewModel>().ToList(),
                10 * 60);

            return this.View(masterpieces);
        }
    }
}