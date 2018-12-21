using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class CategoryProductView: BaseEntity
    {
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}