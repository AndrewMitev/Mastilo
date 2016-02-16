using Autofac;
using Autofac.Integration.Mvc;
using Mastilo.Data;
using Mastilo.Data.Common;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Reflection;
using System.Web.Mvc;

namespace Mastilo.Web.App_Start
{
    public static  class AutofacConfig
    {
        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // Register services
            RegisterServices(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.Register(x => new ApplicationDbContext()).As<DbContext>();

            builder.RegisterGeneric(typeof(DbRepository<>)).As(typeof(IDbRepository<>)).InstancePerRequest();
        }
    }
}