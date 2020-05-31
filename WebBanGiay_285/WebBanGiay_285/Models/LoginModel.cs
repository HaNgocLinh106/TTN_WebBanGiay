using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanGiay_285.Models
{
    public class LoginModel
       
    {
        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage = "Mời bạn nhập tên đăng nhập")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Mời bạn nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        public string Pass { set; get; }

    }
}