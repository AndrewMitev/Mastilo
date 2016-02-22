namespace Mastilo.Web.Controllers
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using Services.Web;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}