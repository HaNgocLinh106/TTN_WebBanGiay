using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBanGiay_285
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Danh mục sản phẩm",
              url: "danh-muc/{metatitle}-{MaDanhMuc}",
              defaults: new { controller = "SanPham", action = "SanPham", id = UrlParameter.Optional },
              namespaces: new[] { "WebBanGiay_285.Controllers" }
          );

            routes.MapRoute(
             name: "Chi tiết sản phẩm",
             url: "chi-tiet-san-pham/{metatitle}-{MaSanPham}",
             defaults: new { controller = "SanPham", action = "Giay", id = UrlParameter.Optional },
             namespaces: new[] { "WebBanGiay_285.Controllers" }
         );

            routes.MapRoute(
            name: "Tài khoản khách hàng",
            url: "tai-khoan-khach-hang/{SDT}-{MaGioHang}",
            defaults: new { controller = "User", action = "TaiKhoanKhachHang", id = UrlParameter.Optional },
            namespaces: new[] { "WebBanGiay_285.Controllers" }
        );
            routes.MapRoute(
            name: "Thêm giỏ hàng",
            //url: "them-gio-hang/{MaGiay}-{SoLuong}",
            url: "them-gio-hang",
            defaults: new { controller = "GioHang", action = "Them", id = UrlParameter.Optional },
            namespaces: new[] { "WebBanGiay_285.Controllers" }
        );
            routes.MapRoute(
           name: "Giỏ hàng",
           url: "gio-hang",
           defaults: new { controller = "GioHang", action = "Index", id = UrlParameter.Optional },
           namespaces: new[] { "WebBanGiay_285.Controllers" }
       );
            routes.MapRoute(
          name: "Thanh toán",
          url: "thanh-toan",
          defaults: new { controller = "GioHang", action = "ThanhToan", id = UrlParameter.Optional },
          namespaces: new[] { "WebBanGiay_285.Controllers" }
      );

            routes.MapRoute(
         name: "Thanh toán thành công",
         url: "hoan-thanh",
         defaults: new { controller = "GioHang", action = "ThanhCong", id = UrlParameter.Optional },
         namespaces: new[] { "WebBanGiay_285.Controllers" }
     );
         routes.MapRoute(
         name: "Đăng nhập",
         url: "dang-nhap",
         defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
         namespaces: new[] { "WebBanGiay_285.Controllers" }
     );
         routes.MapRoute(
         name: "Đăng ký",
         url: "dang-ky",
         defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
         namespaces: new[] { "WebBanGiay_285.Controllers" }
     );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
