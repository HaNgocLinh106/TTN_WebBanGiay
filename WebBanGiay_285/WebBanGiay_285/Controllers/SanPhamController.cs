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

        public PartialViewResult ListSanPham()
        {
            var model = new SanPhamDao().ListSP(3);
            return PartialView(model);
        }

        public ActionResult SanPham(long MaDanhMuc)
        {
            var danhmuc = new DanhMucDao().DanhMucSP(MaDanhMuc);
            ViewBag.SanPham = new DanhMucDao().ListAllSP(danhmuc.MaDanhMuc);
            return View(MaDanhMuc);
        }
       
        public ActionResult Giay(long MaSanPham)
        {
            //var model = new GiayDao().ViewDetail(MaSanPham);     
            //var model = new GiayDao().ViewDetail(MaSanPham);
            //ViewBag.ListGiaylQ = new GiayDao().ListGiaylQ(MaSanPham);
            
            var product = new SanPhamDao().ViewDetail(MaSanPham);
            ViewBag.GiayOD = new GiayDao().ViewDetail(product.MaSanPham);
            ViewBag.Giay = new GiayDao().ListGiaylQ(product.MaSanPham);

            return View(MaSanPham);
        }
    }
}