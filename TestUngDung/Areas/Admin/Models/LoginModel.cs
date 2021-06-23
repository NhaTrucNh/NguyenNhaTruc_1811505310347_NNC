﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestUngDung.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời nhập username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mời nhập password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
