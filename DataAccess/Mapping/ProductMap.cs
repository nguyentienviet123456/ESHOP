using Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class ProductMap: EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");
            HasKey(a => a.Id);

            //HasRequired(x => x.Category)
            //    .WithMany()
            //    .HasForeignKey(x => x.CategoryId)
            //    .WillCascadeOnDelete(true);
        }
    }
}
