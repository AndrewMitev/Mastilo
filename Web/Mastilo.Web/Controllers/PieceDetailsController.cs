using Mastilo.Services.Data.Interfaces;
using Mastilo.Web.ViewModels.MasterpieceViewModels;
using System.Web.Mvc;
using Mastilo.Web.Infrastructure.Mapping;
using System;
using System.Globalization;

namespace Mastilo.Web.Controllers
{
    public class PieceDetailsController : BaseController
    {
        private readonly IMasterpiecesService masterpiecesService;

        public PieceDetailsController(IMasterpiecesService masterpiecesService)
        {
            this.masterpiecesService = masterpiecesService;
        }

        public ActionResult Index(int id = 1)
        {
            var detailedMasterpiece = this.masterpiecesService.GetMasterpieceById(id);
            var piece = this.Mapper.Map<MasterpieceResponseViewModel>(detailedMasterpiece);

            return View(piece);
        }
    }
}