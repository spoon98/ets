using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using ETS.ClientPortal.Core;
using ETS.ClientPortal.Core.Domain;
using ETS.ClientPortal.Infrastructure.Data.EntityFramework.Repositories;
using ETS.ClientPortal.Infrastructure.Data.Specification;

namespace ETS.ClientPortal.Infrastructure.Data.Repositories.Domain.Specification
{
    public class ProductByNameSpecification : Specification<Product>
    {
        public ProductByNameSpecification(string nameToMatch)
            : base(p => p.Name == nameToMatch)
        { 
        }        
    }
}
