﻿namespace Mastilo.Web.Areas.Editor.Controllers
{
    using System.Web.Mvc;
    using Mastilo.Services.Data.Interfaces;
    using Mastilo.Web.Controllers;
    using ViewModels;

    public class DetailsController : BaseController
    {
        private readonly IMasterpiecesService masterpiecesService;

        public DetailsController(IMasterpiecesService masterpiecesService)
        {
            this.masterpiecesService = masterpiecesService;
        }

        public ActionResult Index(int id)
        {
            var masterpiece = this.masterpiecesService.GetMasterpieceById(id);
            var viewModel = this.Mapper.Map<MasterpiecesApproveModel>(masterpiece);

            return this.View(viewModel);
        }
    }
}