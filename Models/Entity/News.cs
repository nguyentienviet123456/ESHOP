using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entity
{
    public class News: BaseEntity
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
