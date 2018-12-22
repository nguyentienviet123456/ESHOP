using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Business.Interface;
using Models.Entity;
using Web.Models.Introduce;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class IntroduceController : Controller
    {
        // GET: Introduce
        private readonly IIntroduceBusiness _introduceBusiness;
        private readonly IProductBusiness _productBusiness;

        public IntroduceController(IIntroduceBusiness introduceBusiness, IProductBusiness productBusiness)
        {
            _introduceBusiness = introduceBusiness;
            _productBusiness = productBusiness;
        }

        public ActionResult Index()
        {
            var introduces = _introduceBusiness.GetIntroduce().ToList();
            var introduce = introduces.SingleOrDefault();
            var products = _productBusiness.GetAllProduct().Skip(0).Take(20).ToList();
            var result = new IntroduceViewModel
            {
                Content = introduce?.Content,
                Products = products,
            };
            return View(result);
        }
    }
}