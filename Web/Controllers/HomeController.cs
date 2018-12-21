using AutoMapper;
using Business.Interface;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        private readonly IProductBusiness _productBusiness;
        private readonly ICategoryBusiness _categoryBusiness;
        public HomeController(IProductBusiness productBusiness, ICategoryBusiness categoryBusiness)
        {
            _productBusiness = productBusiness;
            _categoryBusiness = categoryBusiness;
        }

        public ActionResult Index()
        {
            ICollection<Category> categories = _categoryBusiness.GetAll();
            var totalCategoryModel = categories.Select(Mapper.Map<CategoryProductView>).ToList();
            IEnumerable<Category> top3Category = _categoryBusiness.GetTop3Seller();
            var top3CategoryModel = top3Category.Select(Mapper.Map<CategoryProductView>).ToList();
            foreach(var item in top3CategoryModel)
            {
                item.Products = item.Products.OrderBy(m => m.CategoryId).Take(8).ToList();
            }
            return View(top3CategoryModel);
        }
    }
}