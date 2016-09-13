namespace Mastilo.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Mastilo.Services.Data.Interfaces;
    using Mastilo.Web.Infrastructure.Mapping;
    using Mastilo.Web.ViewModels.GenreViewModels;
    using Mastilo.Web.ViewModels.MasterpieceViewModels;
    using Microsoft.AspNet.Identity;
    using ViewModels.CategoryViewModels;

    [Authorize]
    public class MasterpieceController : BaseController
    {
        private readonly int ItemsPerPage = 5;

        private readonly IGenresService genresService;
        private readonly IMasterpiecesService masterpiecesService;

        public MasterpieceController(IGenresService genresService, IMasterpiecesService masterpiecesService)
        {
            this.genresService = genresService;
            this.masterpiecesService = masterpiecesService;
        }

        public ActionResult Index(int page = 1, bool pending = false)
        {
            string userId = this.User.Identity.GetUserId();

            var masterpieces = new List<MasterpieceResponseViewModel>();

            if (pending)
            {
                masterpieces = this.masterpiecesService.AllByUserPending(userId).To<MasterpieceResponseViewModel>().ToList();
            }
            else
            {
                masterpieces = this.masterpiecesService.AllByUserApproved(userId).To<MasterpieceResponseViewModel>().ToList();
            }

            var postsNumber = this.masterpiecesService.Count();
            var totalPages = (int)Math.Ceiling(postsNumber / (decimal)this.ItemsPerPage);

            var viewModel = new PagableMasterpieces
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Masterpieces = masterpieces
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult GetApprovedMasterpiecesByUser(string userId)
        {
            return this.RedirectToAction("Index", new { page = 1, pending = false });
        }

        [HttpGet]
        public ActionResult GetPendingMasterpiecesByUser(string userId)
        {
            return this.RedirectToAction("Index", new { page = 1, pending = true });
        }

        public ActionResult Create()
        {
            var genres = this.genresService.All().To<GenreViewModel>().ToList();

            var data = new MasterpieceRequestDataModel
            {
                Genres = genres,
                Masterpiece = new MasterpieceRequestViewModel()
            };

            return this.View(data);
        }

        [ValidateAntiForgeryToken]
        public ActionResult CreateMasterpiece(MasterpieceRequestDataModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Create");
            }

            var masterpiece = model.Masterpiece;
            masterpiece.AuthorId = this.User.Identity.GetUserId();

            if (model.SelectedGroups != null)
            {
                foreach (var category in model.SelectedGroups)
                {
                    masterpiece.Categories.Add(new CategoriesViewModel { Name = category });
                }
            }

            this.masterpiecesService.Create(masterpiece.Title, masterpiece.Content, masterpiece.AuthorId, masterpiece.GenreId, this.Mapper.Map<ICollection<Category>>(masterpiece.Categories));
            this.TempData["SuccessCreateMasterpiece"] = "Your masterpiece was successfully created";

            return this.RedirectToAction("Index");
        }
    }
}