using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanGiay_285.Models
{
    public class RegisterModel
    {
        [Key]
        public long MaNguoiDung { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage ="Yêu cầu nhập tên đăng nhập")]
        public string UserName { set; get; }

        [Display(Name = "Mật khẩu")]
        [StringLength(20,MinimumLength =6, ErrorMessage ="Độ dài mật khẩu ít nhất là 6 kí tự. ")]
        public string Pass { set; get; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Yêu cầu nhập họ tên")]
        public string TenNguoiDung { set; get; }

        [Display(Name = "Địa chỉ")]
        public string DiaChi { set; get; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Yêu cầu nhập số điện thoại")]
        public string SDT { set; get; }
    }
}