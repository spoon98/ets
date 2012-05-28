using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETS.ClientPortal.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace ETS.ClientPortal.Infrastructure.Data.Mapping
{
    public class OrderMapping : EntityTypeConfiguration<Order>
    {
        public OrderMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.OrderDate);
            Property(x => x.CustomerId);

            HasRequired<Customer>(x => x.Customer)
                .WithMany(y => y.Orders)                
                .HasForeignKey(o => o.CustomerId);
                
            ToTable("Order");            
        }
    }
}
