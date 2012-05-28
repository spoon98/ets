using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETS.ClientPortal.Core.Domain;

namespace ETS.ClientPortal.Core.Interface.Repository
{
    public interface ICustomerRepository : IRepository
    {
        IList<Customer> NewlySubscribed();

        Customer FindByName(string firstname, string lastname);
    }
}
