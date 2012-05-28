
using System;    
using Microsoft.Practices.ServiceLocation;
using Castle.MicroKernel.Registration;
    
using SharpArch.Core.NHibernateValidator.CommonValidatorAdapter;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Core.PersistenceSupport.NHibernate;
using SharpArch.Data.NHibernate;
using SharpArch.Web.Castle;
using Castle.Windsor;
using Castle.Facilities.TypedFactory;

namespace FIS.DSI.Tests
{
    using ETS.ClientPortal.Core.Interface.Service;

    public class ServiceLocatorInitializer
    {

        public static void Init(IWindsorContainer container)
        {
            RegisterComponentsWith(container);
            //ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
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
                   .FromAssemblyNamed("FIS.DSI.RequestManager.Web")
                   .Pick()
                   .WithService.FirstNonGenericCoreInterface("ETS.ClientPortal.Core"));

            container.Register(
               AllTypes
                   .FromAssemblyNamed("FIS.DSI.RequestManager.Tasks")
                   .Pick()
                   .WithService.FirstNonGenericCoreInterface("ETS.ClientPortal.Core"));



            container.AddFacility<TypedFactoryFacility>();
            container.Register(
                Component.For<ETS.ClientPortal.Core.Interface.Service.IServiceFactory>()
                    .AsFactory()
                    .LifeStyle.Transient);
        }

    }
}
