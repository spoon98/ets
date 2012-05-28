using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using System.Reflection;

using SharpArch.Core.NHibernateValidator.CommonValidatorAdapter;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Core.PersistenceSupport.NHibernate;
using SharpArch.Data.NHibernate;
using SharpArch.Web.Castle;
using Castle.Facilities.TypedFactory;
using ETS.ClientPortal.Core.Interface.Service;
using ETS.ClientPortal.Core;
using ETS.ClientPortal.Infrastructure.Data;
using ETS.ClientPortal.Infrastructure.Data.EntityFramework;

namespace ETS.ClientPortal.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container = new WindsorContainer();
        private WebObjectContextStorage _storage;

        static MvcApplication()
        {
            RegisterComponentsWith(_container);
        }

        public override void Init()
        {
            base.Init();
            _storage = new WebObjectContextStorage(this);
        }        
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(_container));
        }
        
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            ObjectContextInitializer.Instance().InitializeObjectContextOnce(() =>
            {
                ObjectContextManager.InitStorage(_storage);
                ObjectContextManager.Init(new[] { Server.MapPath("~/bin/ETS.ClientPortal.Infrastructure.Data") });
            });
        }
        
        private static void RegisterComponentsWith(IWindsorContainer container)
        {
            container.Register(
                Component.For(typeof(IRepository<>))
                .ImplementedBy(typeof(Repository<>))
                .Named("repositoryType"));

            container.Register(
               AllTypes
                   .FromAssemblyNamed("ETS.ClientPortal.Infrastructure.Data")
                   .Pick()
                   .WithService.FirstNonGenericCoreInterface("ETS.ClientPortal.Core"));

            container.Register(
               AllTypes
                   .FromAssemblyNamed("ETS.ClientPortal.Infrastructure.Data.EntityFramework")
                   .Pick()
                   .WithService.FirstNonGenericCoreInterface("ETS.ClientPortal.Core"));

            container.Register(
               AllTypes
                   .FromAssemblyNamed("ETS.ClientPortal.Web")
                   .Pick()
                   .WithService.FirstNonGenericCoreInterface("ETS.ClientPortal.Core"));

            container.Register(
               AllTypes
                   .FromAssemblyNamed("ETS.ClientPortal.Tasks")
                   .Pick()
                   .WithService.FirstNonGenericCoreInterface("ETS.ClientPortal.Core"));



            container.AddFacility<TypedFactoryFacility>();
            container.Register(
                Component.For<IServiceFactory>()
                    .AsFactory()
                    .LifeStyle.Transient);
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

    }
}