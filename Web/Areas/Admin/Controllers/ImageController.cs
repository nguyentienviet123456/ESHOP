using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Admin.Models;
using Web.Models;

namespace Web.Areas.Admin.Controllers
{
    public class ImageController : Controller
    {
        Paging pg = new Paging();
        // GET: Admin/Image
        public ActionResult View()
        {
          
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            int offset = 1;
            int Page = 1;
            int Take = 20;
            if (Convert.ToInt32(Request.QueryString["Page"]) > 1)
            {
                Page = Convert.ToInt32(Request.QueryString["Page"]);
            }

            int skip = 0;
            if (Page == 1)
                skip = 0;
            else
                skip = ((Page - 1) * Take);
            
            DirectoryInfo d = new DirectoryInfo(Server.MapPath("~/Areas/Admin/Assets/img"));
            var Files = d.GetFiles().Skip(skip).Take(Take);
            string str = "";
            var listImage = new List<ViewImageModel>();
            foreach (FileInfo file in Files)
            {
                str = str + ", " + file.Name;
                listImage.Add(new ViewImageModel
                {
                    Name = file.Name,
                    Url = "/Areas/Admin/Assets/img/" + file.Name
                });
            }
            int total = d.GetFiles().Count();
            var data = listImage;
            string paging = pg.Pagination(total, Page, Take, offset, controllerName + "/", actionName, "");
            ViewBag.Paging = paging;
            return View(data.ToList());
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string uploaPath = Server.MapPath("~/Areas/Admin/Assets/img");
                if (!Directory.Exists(uploaPath))
                {
                    Directory.CreateDirectory(uploaPath);
                }
                var path = Path.Combine(uploaPath, file.FileName);
                file.SaveAs(path);
            }
            return RedirectToAction("View");
        }

        public ActionResult PrepareSearch()
        {
            var model = new ViewImageModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(ViewImageModel model)
        {
            DirectoryInfo d = new DirectoryInfo(Server.MapPath("~/Areas/Admin/Assets/img"));
            FileInfo[] Files = d.GetFiles();
            string str = "";
            var listImage = new List<ViewImageModel>();
            foreach (FileInfo file in Files)
            {
                str = str + ", " + file.Name;
                listImage.Add(new ViewImageModel
                {
                    Name = file.Name,
                    Url = "/Areas/Admin/Assets/img/" + file.Name
                });
            }

            var result = listImage.Where(m => m.Name.Contains(model.Name));
            return View(result);
        }
    }
}