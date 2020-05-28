using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace WebBanGiay_285.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult DanhMuc()
        {
            var model = new DanhMucDao().ListAll();
            return PartialView(model);
        }

        public ActionResult SanPham(long MaDanhMuc)
        {
            var model = new DanhMucDao().ListAllSP(MaDanhMuc);
            return View(model);
        }
        //public ActionResult Giay(long MaSanPham)
        //{
        //    var sp = new GiayDao().ViewDetail(MaSanPham);
        //    ViewBag.SanPham = new SanPhamDao().ViewDetail(sp.MaSanPham.Value);
        //    ViewBag.LienQuan = new GiayDao().ListGiaylQ(MaSanPham);
        //    return View(sp);
        //}
        public ActionResult Giay(long MaSanPham)
        {
            var model = new GiayDao().ViewDetail(MaSanPham);
            ViewBag.ListGiaylQ = new GiayDao().ListGiaylQ(MaSanPham);
            return View(model);
        }
    }
}