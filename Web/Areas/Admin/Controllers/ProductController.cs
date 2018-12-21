using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Business.Interface;
using Models.Entity;
using Web.Areas.Admin.Models;

namespace Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryBusiness _categoryBusiness;
        private readonly IProductBusiness _productBusiness;

        public ProductController(ICategoryBusiness categoryBusiness, IProductBusiness productBusiness)
        {
            _categoryBusiness = categoryBusiness;
            _productBusiness = productBusiness;
        }

        // GET: Admin/Product
        public ActionResult Index()
        {
            var categories = _categoryBusiness.GetAll();
            return View(categories);
        }

        public ActionResult AddProduct()
        {
            var product = new AddProductModel();
            PrepareModel(product);
            return View(product);
        }

        [HttpPost]
        public ActionResult AddProduct(AddProductModel model)
        {
            var product = Mapper.Map<Product>(model);
            _productBusiness.AddOrUpdate(product);
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var product = _productBusiness.GetProductById(id);
            var model = Mapper.Map<AddProductModel>(product);
            PrepareModel(model);
            model.Id = product.Id;
            return View(model);
        }

        private void PrepareModel(AddProductModel model)
        {
            var categories = _categoryBusiness.GetAll();
            model.AvailableCategories = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Selected = true
                }
            };
            foreach (var item in categories)
            {
                model.AvailableCategories.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.CategoryName
                });
            }
        }
    }
}