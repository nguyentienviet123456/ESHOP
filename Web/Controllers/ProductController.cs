using AutoMapper;
using Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Models.ProductModel;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        Paging pg = new Paging();
        private readonly IProductBusiness _productBusiness;
        
        public ProductController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }
        // GET: Product
        public ActionResult AllProducts()
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            int offset = 1;
            int Page = 1;
            int Take = 10;
            if (Convert.ToInt32(Request.QueryString["Page"]) > 1)
            {
                Page = Convert.ToInt32(Request.QueryString["Page"]);
            }

            int skip = 0;
            if (Page == 1)
                skip = 0;
            else
                skip = ((Page - 1) * Take);
            int total = _productBusiness.GetAllProduct().Count();
            var data = _productBusiness.GetAllProduct().Skip(skip).Take(Take);
            string paging = pg.Pagination(total, Page, Take, offset, controllerName + "/", actionName, "");
            ViewBag.Paging = paging;
            return View(data.ToList());
        }

        [HttpGet]
        public ActionResult SingleProduct(int id)
        {
            var product = _productBusiness.GetProductById(id);
            var model = Mapper.Map<ProductView>(product);
            ViewBag.Content = model.Content;
            return View(model);
        }
    }
}