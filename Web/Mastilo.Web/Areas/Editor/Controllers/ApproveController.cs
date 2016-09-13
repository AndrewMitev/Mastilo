namespace Mastilo.Web.Areas.Editor.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data.Interfaces;
    using ViewModels;

    [Authorize(Roles = "Editor")]
    public class ApproveController : Controller
    {
        private const string ApproveMessage = "Произведението бе успешно одобрено!";

        private const string RejectMessage = "Рецензията бе успешно запазена";

        private readonly IMasterpiecesService masterpiecesService;

        public ApproveController(IMasterpiecesService masterpiecesService)
        {
            this.masterpiecesService = masterpiecesService;
        }

        public ActionResult New()
        {
            return this.View();
        }

        public ActionResult Edited()
        {
            return this.View();
        }

        public ActionResult LoadGridNew()
        {
            var pieces = this.masterpiecesService
                .AllNotAssessed()
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

        public ActionResult LoadGridEdited()
        {
            var pieces = this.masterpiecesService
                .AllPendingAssessed()
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

        public ActionResult Approve(int id)
        {
            this.masterpiecesService.UpdatePendingStatus(id, true);

            this.TempData["approveMessage"] = ApproveMessage;
            return this.RedirectToAction("New");
        }

        [ValidateAntiForgeryToken]
        public ActionResult Reject(MasterpiecesApproveModel model)
        {
            this.masterpiecesService.AddDisapprovedMessage(model.Id, model.DisapprovedMessage);

            this.TempData["rejectMessage"] = RejectMessage;
            return this.RedirectToAction("New");
        }
    }
}