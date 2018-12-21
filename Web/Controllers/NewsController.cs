using AutoMapper;
using Business.Interface;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Models.News;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class NewsController : Controller
    {
        Paging pg = new Paging();
        private readonly INewsBusiness _newsbusiness;
        public NewsController( INewsBusiness newsBusiness)
        {
            _newsbusiness = newsBusiness;
        }
            // GET: News
        [HttpGet]
        public JsonResult GetAllNewss()
        {
            ICollection<News> newss = _newsbusiness.GetAllNewss();
            var totalNews = newss.Select(Mapper.Map<NewsView>).ToList();
            return Json(new { newss = totalNews }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetLastestNews()
        {
            var news = _newsbusiness.GetLastestNews();
            var newsModel = Mapper.Map<NewsView>(news);
            return Json(new { lastest = newsModel }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult All()
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            int offset = 1;
            int Page = 1;
            int Take = 5;
            if (Convert.ToInt32(Request.QueryString["Page"]) > 1)
            {
                Page = Convert.ToInt32(Request.QueryString["Page"]);
            }

            int skip = 0;
            if (Page == 1)
                skip = 0;
            else
                skip = ((Page - 1) * Take);
            int total = _newsbusiness.GetAllNewss().Count();
            var data = _newsbusiness.GetAllNewss().Skip(skip).Take(Take);
            string paging = pg.Pagination(total, Page, Take, offset, controllerName + "/", "/" + actionName, "");
            ViewBag.Paging = paging;
            return View(data.ToList());
        }

        [HttpGet]
        public ActionResult GetSingleNews(int id)
        {
            var news = _newsbusiness.GetNewsById(id);
            var newsModel = Mapper.Map<NewsView>(news);
            return View(newsModel);
        }
    }
}