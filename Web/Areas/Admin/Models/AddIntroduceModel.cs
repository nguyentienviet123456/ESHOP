using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Models
{
    public class AddIntroduceModel
    {
        public int Id { get; set; }
        [AllowHtml]
        public string Content { get; set; }
    }
}