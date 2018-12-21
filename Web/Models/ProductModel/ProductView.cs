using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.ProductModel
{
    public class ProductView: BaseEntity
    {
        public string Content { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string Price { get; set; }
        public string PriceDiscount { get; set; }
        public string Address { get; set; }
        public virtual Category Category { get; set; }
    }
}