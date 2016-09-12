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

            string[] paramsInUrl = filterContext.HttpContext.Request.Path.Split('/');
            int id;

            if (!int.TryParse(paramsInUrl[paramsInUrl.Length - 1], out id))
            {
                id = 1;
            }

            var masterpieceService = (filterContext.Controller as PieceDetailsController).masterpiecesService;

            masterpieceService.IncreaseViewCount(id);

            base.OnActionExecuted(filterContext);
        }
    }
}