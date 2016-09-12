namespace Mastilo.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data.Interfaces;
    using ViewModels.MasterpieceViewModels;

    public class ExploreController : BaseController
    {
        private readonly IMasterpiecesService masterpiecesService;
        private const int ItemsPerPage = 5;

        public ExploreController(IMasterpiecesService masterpiecesService)
        {
            this.masterpiecesService = masterpiecesService;
        }

        public ActionResult Index()
        {
            //var masterpieces = this.Cache.Get(
            //    "masterpieces",
            //    () => this.masterpiecesService.AllSortedByDate().To<MasterpieceResponseViewModel>().ToList(),
            //    10 * 60);

            var masterpieces = this.masterpiecesService.GetMasterpiecesByPageAndSort(string.Empty, "descending", string.Empty, 1, ItemsPerPage).To<MasterpieceResponseViewModel>().ToList();

            return this.View(new PagableMasterpieces() { Masterpieces = masterpieces, CurrentPage = 1, TotalPages = (int)Math.Ceiling(this.masterpiecesService.Count() / (decimal)ItemsPerPage) });
        }

        [HttpPost]
        public ActionResult Index(PagableMasterpieces model)
        {
            var page = model.CurrentPage;
            var sortType = model.SortField;
            var sortDirection = model.SortDirection;
            var searchValue = model.Search;

            var masterpieces = this.masterpiecesService.GetMasterpiecesByPageAndSort(sortType, sortDirection, searchValue, page, ItemsPerPage).To<MasterpieceResponseViewModel>().ToList();
            var postsNumber = 0;
            var totalPages = 0;

            if (model.Search == string.Empty || model.Search == null)
            {
                postsNumber = this.masterpiecesService.Count();
            }
            else
            {
                postsNumber = masterpieces.Count();
            }

            totalPages = (int)Math.Ceiling(postsNumber / (decimal)ItemsPerPage);

            model.TotalPages = totalPages;
            model.Masterpieces = masterpieces;

            var viewModel = model;

            return this.View(viewModel);
        }
    }
}