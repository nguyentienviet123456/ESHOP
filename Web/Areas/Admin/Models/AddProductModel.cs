using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Entity;

namespace Web.Areas.Admin.Models
{
    public class AddProductModel
    {
        public int Id { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string PriceDiscount { get; set; }
        public string Address { get; set; }
        public int CategoryId { get; set; }
        public List<SelectListItem> AvailableCategories { get; set; }
    }
}