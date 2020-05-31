using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiay_285.Common;
using WebBanGiay_285.Models;

namespace WebBanGiay_285.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, model.Pass);
                if (result)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.MaNguoiDung = user.MaNguoiDung;
   
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }             
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công.");
                }
            }
            return View("Login");
        }

        [HttpGet]
        public ActionResult Register ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
           if(ModelState.IsValid)
            {
                var dao = new UserDao();
                if(dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }    
                else if(dao.CheckSDT(model.SDT))
                {
                    ModelState.AddModelError("", "Số điện thoại đã tồn tại");
                }    
                else
                {
                    var user = new NguoiDung();
                    user.TenNguoiDung = model.TenNguoiDung;
                    user.UserName = model.UserName;
                    user.Pass = model.Pass;
                    user.DiaChi = model.DiaChi;
                    user.SDT = model.SDT;
                   var result = dao.Insert(user);
                    if(result>0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterModel();
                    }    
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }    
                }    
            }
            return View(model);
        }
        public ActionResult TaiKhoan(string SDT)
        {
            var model = new UserDao().TaiKhoanND(SDT);
            return View(model);
        }

        public ActionResult TaiKhoanKhachHang(long MaGioHang)
        {

            var model = new UserDao().ListBySDT(MaGioHang);
            return View(model);
        }

    }
}
