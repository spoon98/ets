using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using ETS.ClientPortal.Core.Domain;

namespace ETS.ClientPortal.Infrastructure.Data.Mapping
{
    public class CategoryMapping : EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Name);

            //HasMany(x => x.Products)
            //   .WithMany(y => y.Categories)
            //   .Map(m =>
            //   {
            //       m.ToTable("ProductsInCategories");
            //   });

            ToTable("Category");
        }
    }
}
