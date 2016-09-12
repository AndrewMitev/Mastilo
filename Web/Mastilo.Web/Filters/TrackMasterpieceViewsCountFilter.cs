namespace Mastilo.Web.Filters
{
    using System.Web.Mvc;
    using Controllers;

    public class TrackMasterpieceViewsCountFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if ((filterContext.Controller as PieceDetailsController) == null)
            {
                return;
            }

            int id = int.Parse(filterContext.HttpContext.Request.Params.Get("id"));

            var masterpieceService = (filterContext.Controller as PieceDetailsController).masterpiecesService;

            masterpieceService.IncreaseViewCount(id);

            base.OnActionExecuted(filterContext);
        }
    }
}