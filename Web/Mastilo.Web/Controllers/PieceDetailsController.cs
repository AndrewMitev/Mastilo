namespace Mastilo.Web.Controllers
{
    using System.Web.Mvc;
    using Mastilo.Services.Data.Interfaces;
    using Mastilo.Web.ViewModels.MasterpieceViewModels;

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

            return this.View(piece);
        }
    }
}