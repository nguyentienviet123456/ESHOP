using System;
using AutoMapper;
using Business.Interface;
using Models.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [AllowAnonymous]
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

        // GET: Category
        [HttpGet]
        public JsonResult GetAllCategory()
        {
            ICollection<Category> categories = _categoryBusiness.GetAll();
            var totalCategoryModel = categories.Select(Mapper.Map<CategoryView>).ToList();
            return Json(new{categories = totalCategoryModel},JsonRequestBehavior.AllowGet);
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
            
            string paging = pg.Pagination(totalProducts, Page, Take, offset, controllerName + "/",actionName, "/" + id);
            ViewBag.CategoryName = category.CategoryName;
            ViewBag.Paging = paging;
            ViewBag.Title = ViewBag.CategoryName;
            return View(products.ToList());
        }
    }
}