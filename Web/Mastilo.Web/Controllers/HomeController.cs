namespace Mastilo.Web.Controllers
{
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return this.View();
            }

            return this.Redirect("/Explore");
        }
    }
}