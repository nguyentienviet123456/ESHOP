using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Interface;
using Models.Entity;
using Web.Models;

namespace Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        Paging pg = new Paging();
        private readonly ICategoryBusiness _categoryBusiness;
        private readonly IProductBusiness _productBusiness;
        public CategoryController(ICategoryBusiness categoryBusiness, IProductBusiness productBusiness)
        {
            _categoryBusiness = categoryBusiness;
            _productBusiness = productBusiness;
        }
        // GET: Admin/Category
        public ActionResult Index(Category model)
        {
            var allCategories = _categoryBusiness.GetAll();
            return View(allCategories);
        }

        public ActionResult CreateNew()
        {
            var model = new Category();
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var category = _categoryBusiness.GetById(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult CreateCategory(Category model)
        {
            _categoryBusiness.AddOrUpdate(model);
            return RedirectToAction("Index", "Category");
        }

        [HttpPost]
        public ActionResult Edit(Category model)
        {
            _categoryBusiness.AddOrUpdate(model);
            return RedirectToAction("Index", "Category");
        }

        public ActionResult Delete(int id)
        {
            var category = _categoryBusiness.GetById(id);
            _categoryBusiness.Remove(category);
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            int offset = 1;
            int Page = 1;
            int Take = 8;
            if (Convert.ToInt32(Request.QueryString["Page"]) > 1)
            {
                Page = Convert.ToInt32(Request.QueryString["Page"]);
            }

            int skip = 0;
            if (Page == 1)
                skip = 0;
            else
                skip = ((Page - 1) * Take);

            var category = _categoryBusiness.GetById(id);
            var products = _productBusiness.GetProductsByCategoryid(id).Skip(skip).Take(Take);
            var totalProducts = _productBusiness.GetProductsByCategoryid(id).Count();

            string paging = pg.Pagination(totalProducts, Page, Take, offset, controllerName + "/", actionName, "/" + id);
            ViewBag.CategoryName = category.CategoryName;
            ViewBag.Paging = paging;
            ViewBag.Title = ViewBag.CategoryName;
            return View(products.ToList());
        }
    }
}