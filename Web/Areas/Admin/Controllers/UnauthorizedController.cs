using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class UnauthorizedController : Controller
    {
        // GET: Admin/Unauthorized
        public ActionResult Index()
        {
            return View();
        }
    }
}