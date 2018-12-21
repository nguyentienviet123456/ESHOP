using Business.Implement;
using Business.Interface;
using DataAccess.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace Web.Factory
{
    public class UnityResolver
    {
        public static void Register(UnityContainer container)
        {
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IProductBusiness, ProductBusiness>();
            container.RegisterType<ICategoryBusiness, CategoryBusiness>();
            container.RegisterType<INewsBusiness, NewsBusiness>();
            container.RegisterType<IRegisterBusiness, RegisterBusiness>();
            container.RegisterType<IIntroduceBusiness, IntroduceBusiness>();
        }
    }
}