using System.Collections.Generic;
using Models.Entity;

namespace Web.Models.Introduce
{
    public class IntroduceViewModel
    {
        public string Content { get; set; }
        public List<Product> Products { get; set; }
    }
}