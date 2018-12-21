using AutoMapper;
using Business.Interface;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.Register;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly IRegisterBusiness _registerBusiness;

        public RegisterController(IRegisterBusiness registerBusiness)
        {
            _registerBusiness = registerBusiness;
        }
        // GET: Register
        [HttpPost]
        public JsonResult Register(RegisterPost model)
        {
            var modelPost = Mapper.Map<Register>(model);
            _registerBusiness.AddRegister(modelPost);
            return Json(new
            {
                result = "success"
            }, JsonRequestBehavior.AllowGet);
        }
    }
}