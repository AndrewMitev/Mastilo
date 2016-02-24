namespace Mastilo.Web
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Mastilo.Data;
    using Mastilo.Data.Migrations;
    using Mastilo.Web.App_Start;
    using Mastilo.Web.Infrastructure.Mapping;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            AutofacConfig.RegisterAutofac();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var autoMapper = new AutoMapperConfig();
            autoMapper.Execute(Assembly.GetExecutingAssembly());
        }
    }
}
