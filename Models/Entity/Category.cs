using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entity
{
    public class Category: BaseEntity
    {
        public string CategoryName { get; set; }
        private ICollection<Product> _product;
        public virtual ICollection<Product> Products
        {
            get { return _product ?? (_product = new List<Product>()); }
            protected set { _product = value; }
        }
    }
}
