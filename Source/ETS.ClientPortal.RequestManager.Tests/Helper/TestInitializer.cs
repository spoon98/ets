using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Configuration;
using Castle.Windsor;
using ETS.ClientPortal.Infrastructure.Data.EntityFramework;
using System.Data.Objects;

namespace FIS.DSI.Tests.Helper
{
    [TestClass]
    public class TestInitializer
    {
        private static bool _isInitialize;
        private static Configuration _conifg;

        public static Configuration Configuration
        {
            get
            {
                if (!_isInitialize)
                    throw new ApplicationException("You must call the Initialize() method before accessing this property.");

                return _conifg;
            }
        }

        public static void Initialize(IWindsorContainer container, SimpleObjectContextStorage storage)
        {
            if (_isInitialize)
                return;

            ServiceLocatorInitializer.Init(container);
            
            try
            {
                ObjectContextInitializer.Instance().InitializeObjectContextOnce(() =>
                {
                    //ObjectContextBuilder<ObjectContext> builder = new ObjectContextBuilder<ObjectContext>("DSI", new[] { "ETS.ClientPortal.Infrastructure.Data" }, true, true);
                    //ObjectContextManager.Current = builder.BuildObjectContext();
                    ObjectContextManager.InitStorage(storage);
                    ObjectContextManager.Init(new[] { AppDomain.CurrentDomain.BaseDirectory + "//ETS.ClientPortal.Infrastructure.Data" });
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
            _isInitialize = true;
        }
    }
}
