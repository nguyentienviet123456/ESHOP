using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Business.Interface;
using Models.Entity;
using Web.Areas.Admin.Models;

namespace Web.Areas.Admin.Controllers
{
    public class IntroduceController : Controller
    {
        // GET: Admin/Introduce
        private readonly IIntroduceBusiness _introduceBusiness;
        public IntroduceController(IIntroduceBusiness introduceBusiness)
        {
            _introduceBusiness = introduceBusiness;
        }

        public ActionResult Index()
        {
            var introduces = _introduceBusiness.GetIntroduce().ToList();
            var introduce = introduces.SingleOrDefault();
            return View(Mapper.Map<AddIntroduceModel>(introduce));
        }

        [HttpPost]
        public ActionResult AddIntroduce(AddIntroduceModel model)
        {
            var introduce = Mapper.Map<Introduce>(model);
            _introduceBusiness.AddOrUpdate(introduce);
            return RedirectToAction("Index", "Introduce");
        }
    }
}