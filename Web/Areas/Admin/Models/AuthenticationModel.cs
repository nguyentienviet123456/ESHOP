using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.Admin.Models
{
    public class AuthenticationModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "username is required !")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "password is required !")]
        public string Password { get; set; }
    }
}