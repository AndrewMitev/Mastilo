namespace Mastilo.Web.Areas.Editor.Controllers
{
    using Infrastructure.Mapping;
    using Services.Data.Interfaces;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels;

    [Authorize(Roles = "Editor")]
    public class ApproveController : Controller
    {
        private readonly IMasterpiecesService masterpiecesService;

        public ApproveController(IMasterpiecesService masterpiecesService)
        {
            this.masterpiecesService = masterpiecesService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult LoadGrid()
        {
            var pieces = this.masterpiecesService
                .AllPendingNotAssessed()
                .To<MasterpiecesApproveModel>()
                .ToList();

            var jsonData = new
            {
                total = 1,
                page = 1,
                records = pieces.Count,
                rows = (
                        from item in pieces
                        select new
                        {
                            id = item.Id,
                            cell = new string[]
                            {
                                item.Title,
                                item.Genre
                            }
                        }).ToArray()
            };

            return this.Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Approve(int id, bool pendingStatus = false)
        {
            this.masterpiecesService.UpdatePendingStatus(id, pendingStatus);

            // TODO: Add notification

            return this.RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public ActionResult Reject(MasterpiecesApproveModel model)
        {
            this.masterpiecesService.AddDisapprovedMessage(model.Id, model.DisapprovedMessage);

            // TODO: Add notification

            return this.RedirectToAction("Index");
        }
    }
}