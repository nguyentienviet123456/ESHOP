﻿using System;
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
        PagingSeo pg = new PagingSeo();
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
        public ActionResult View(int id, string categoryName)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            //string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string controllerName = "danh-muc-san-pham";
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
            
            string paging = pg.PaginationSeo(totalProducts, Page, Take, offset, controllerName + "/",actionName, "" + id, category.CategoryName.ConvertToUnSign3().ToSeoUrl());
            ViewBag.CategoryName = category.CategoryName;
            ViewBag.Paging = paging;
            ViewBag.Title = ViewBag.CategoryName;
            string expectedName = category.CategoryName.ConvertToUnSign3().ToSeoUrl();
            string actualName = (categoryName ?? "").ToLower();

            // permanently redirect to the correct URL
            if (expectedName != actualName)
            {
                return RedirectToActionPermanent("View", "Category", new { id = category.Id, productName = expectedName });
            }
            return View(products.ToList());
        }
    }
}