using AutoMapper;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Admin.Models;
using Web.Models;
using Web.Models.Introduce;
using Web.Models.ProductModel;

namespace Web.Mapping
{
    public class MapperConfig
    {
        public static void ConfigureMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, CategoryView>();
                cfg.CreateMap<Product, AddProductModel>();
                cfg.CreateMap<AddProductModel, Product>();
                cfg.CreateMap<IntroduceViewModel, Introduce>();
            });
        }
    }
}