using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cua_Hang_Thu_Cung.DAO
{
    public class LoginDAO
    {
        [Required]
        public string Email { set; get; }
        public string Password { set; get; }
        public bool RememberMe { set; get; }
    }
}