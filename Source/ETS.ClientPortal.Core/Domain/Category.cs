using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETS.ClientPortal.Core.Domain
{
    public class Category : Entity
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual IList<Product> Products { get; set; }
    }
}
