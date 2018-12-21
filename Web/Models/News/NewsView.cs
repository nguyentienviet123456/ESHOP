using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.News
{
    public class NewsView: BaseEntity
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime UploadDate { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
    }
}