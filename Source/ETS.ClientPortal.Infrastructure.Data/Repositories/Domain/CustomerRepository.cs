using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using ETS.ClientPortal.Core;
using ETS.ClientPortal.Core.Domain;
using ETS.ClientPortal.Infrastructure.Data.EntityFramework.Repositories;
using ETS.ClientPortal.Core.Interface.Repository;

namespace ETS.ClientPortal.Infrastructure.Data.Repositories.Domain
{
    /// <summary>
    /// demostrate an implementation of specific repository
    /// </summary>
    public class CustomerRepository : GenericRepository, ICustomerRepository
    {
        public CustomerRepository()
            : base()
        {
        }

        public CustomerRepository(ObjectContext context)
            : base(context)
        {
        }

        public IList<Customer> NewlySubscribed()
        {
            var lastMonth = DateTime.Now.Date.AddMonths(-1);

            return GetQuery<Customer>().Where(c => c.Inserted >= lastMonth)
                              .ToList();
        }

        public Customer FindByName(string firstname, string lastname)
        {
            return GetQuery<Customer>().Where(c => c.Firstname == firstname && c.Lastname == lastname)
                              .FirstOrDefault();
        }
    }
}
