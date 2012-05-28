using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Castle.Windsor;
using ETS.ClientPortal.Infrastructure.Data.EntityFramework;

namespace FIS.DSI.Tests.Helper
{    
    public class BaseTestRequiringRepositoryAccess
    {
        protected static IWindsorContainer _container = new WindsorContainer();
        protected SimpleObjectContextStorage _storage;

        public BaseTestRequiringRepositoryAccess()
        {

            try
            {
                _storage = new SimpleObjectContextStorage();
                TestInitializer.Initialize(_container, _storage);
            }
            catch (Exception)
            {
                
                throw;
            }
        }        
    }
}
