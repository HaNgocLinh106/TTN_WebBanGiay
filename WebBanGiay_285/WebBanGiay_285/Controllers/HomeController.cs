using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanGiay_285.Controllers
{
    public class HomeController : Controller
    {
        WebGiay db = new WebGiay();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllSanPham()
        {
            var model = db.SanPhams.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult TimKiem(string search)
        {
            var model = new SanPhamDao().TimKiemSP(search);
            return View( model);
        }
    }
}