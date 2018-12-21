using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Areas.Admin.Models;

namespace Web.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            //HttpCookie authCookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            //if (string.IsNullOrEmpty(authCookie?.Value))
            //{
            //    return View();
            //}
            //return RedirectToAction("Index", "Home");
            if (HttpContext.Session["Admin"] == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Index(AuthenticationModel model)
        {
            if (ModelState.IsValid)
            {
                HttpCookie authCookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (model.UserName == null || model.UserName != "admin" || model.Password != "admin@888666")
                {
                    ModelState.AddModelError("EmailOrPassword", "Not authencation");
                    return View(model);
                }
                FormsAuthentication.SetAuthCookie(model.UserName, true);
                HttpContext.Session["Admin"] = true;
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}