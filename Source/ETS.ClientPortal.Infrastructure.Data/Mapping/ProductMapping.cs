﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETS.ClientPortal.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace ETS.ClientPortal.Infrastructure.Data.Mapping
{
    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Name);
            Property(x => x.Description);
            Property(x => x.Price);

            // many to many relationship
            HasMany(x => x.Categories)
                .WithMany(y => y.Products)
                .Map(m =>
                {                    
                    m.ToTable("ProductsInCategories");
                    m.MapLeftKey("ProductId"); // optional, to specify/override the column named ProductId (instead of auto-generated Product_Id) for a many-to-many relationship
                    m.MapRightKey("CategoryId"); // optional, to explicitly specify the column named "CategoryId" instead of auto-generated Category_Id for a many-to-many relationship
                });

            ToTable("Product");
        }
    }
}
