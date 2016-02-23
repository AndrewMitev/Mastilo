﻿namespace Mastilo.Web.Controllers
{
    using Areas.Editor.ViewModels;
    using Infrastructure.Mapping;
    using Services.Data.Interfaces;
    using System.Linq;
    using System.Web.Mvc;

    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IMasterpiecesService masterpiecesService;

        public HomeController(IMasterpiecesService masterpiecesService)
        {
            this.masterpiecesService = masterpiecesService;
        }

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Explore");
            }

            var masterpieces = this.masterpiecesService
                .AllPendingAssessed()
                .To<MasterpieceResponseViewModel>()
                .ToList();

            return this.View(masterpieces);
        }
    }
}