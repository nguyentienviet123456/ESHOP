using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.Register
{
    public class RegisterPost: BaseEntity
    {
        public string FullName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
    }
}