using Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class ContactMap: EntityTypeConfiguration<Contact>
    {
        public ContactMap()
        {
            ToTable("Contact");
            HasKey(o => o.Id);
        }
    }
}
