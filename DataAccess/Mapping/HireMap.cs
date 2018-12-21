using Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class HireMap : EntityTypeConfiguration<Hire>
    {
        public HireMap()
        {
            ToTable("Hire");
            HasKey(o => o.Id);
        }
    }
}
