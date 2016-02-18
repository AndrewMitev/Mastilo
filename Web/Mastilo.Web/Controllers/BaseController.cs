namespace Mastilo.Web.Controllers
{
    using Services.Web;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        public ICacheService Cache { get; set; }
    }
}