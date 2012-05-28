using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FIS.DSI.Tests.Helper;
using ETS.ClientPortal.Infrastructure.Data.EntityFramework;
using ETS.ClientPortal.Infrastructure.Data.EntityFramework.Repositories;
using ETS.ClientPortal.Core.Domain;
using ETS.ClientPortal.Tests.Data.Repository;

namespace FIS.DSI.Tests
{
    [TestClass]
    public class UnitTest1 : BaseTestRequiringRepositoryAccess
    {
        [TestMethod]
        public void TestMethod1()
        {
            var test = new RepositoryTest();
            test.Test();

            //var c = ObjectContextManager.Current;

        }

        //public void SeedDB()
        //{
        //    ObjectContextManager.Current.GetObjectByKey(CreateObjectSet<Product>();
        //}
    }
}
