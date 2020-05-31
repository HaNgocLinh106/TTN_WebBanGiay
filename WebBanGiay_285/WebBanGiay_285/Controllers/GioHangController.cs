using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiay_285.Models;
using System.Web.Script.Serialization;

namespace WebBanGiay_285.Controllers
{
    public class GioHangController : Controller
    {
        private const string GioHangSession = "GioHangSession";
        // GET: GioHang
        public ActionResult Index()
        {
            var GioHang = Session[GioHangSession];
            var list = new List<GioHangIT>();
            if(GioHang != null)
            {
                list = (List<GioHangIT>)GioHang;
            }    
            return View(list);
        }

        public JsonResult XoaAll()
        {
            Session[GioHangSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Xoa(long id)
        {
            var sessionGioHang = (List<GioHangIT>)Session[GioHangSession];
            sessionGioHang.RemoveAll(x => x.Giay.MaGiay == id);
            Session[GioHangSession] = sessionGioHang;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult CapNhat(string GioHangModel)
        {
            var jsonGioHang = new JavaScriptSerializer().Deserialize<List<GioHangIT>>(GioHangModel);
            var sessionGioHang = (List<GioHangIT>) Session[GioHangSession];

            foreach(var item in sessionGioHang)
            {
                var jsonItem = jsonGioHang.SingleOrDefault(x => x.Giay.MaGiay == item.Giay.MaGiay);
                if (jsonItem != null)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }    
                   
            }
            Session[GioHangSession] = sessionGioHang;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult Them(long MaGiay, int SoLuong)
        {
            var giay = new GiayDao().ViewDetail(MaGiay);
            var GioHang = Session[GioHangSession];
            if (GioHang != null)
            {
                var list = (List<GioHangIT>)GioHang;
                if (list.Exists(x => x.Giay.MaGiay == MaGiay))
                {
                    foreach (var item in list)
                    {
                        if (item.Giay.MaGiay == MaGiay)
                        {
                            item.SoLuong += SoLuong;
                        }
                    }
                }
                else
                {
                    //Tạo mới đối tượng GioHangIT
                    var item = new GioHangIT();
                    item.Giay = giay;
                    item.SoLuong = SoLuong;
                    list.Add(item);
                }
                //Gán vào sesion
                Session[GioHangSession] = list;
            }
            else
            {
                //Tạo mới đối tượng GioHangIT
                var item = new GioHangIT();
                item.Giay = giay;
                item.SoLuong = SoLuong;
                var list = new List<GioHangIT>();
                list.Add(item);

                //Gán vào sesion
                Session[GioHangSession] = list;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ThanhToan()
        {
            var GioHang = Session[GioHangSession];
            var list = new List<GioHangIT>();
            if (GioHang != null)
            {
                list = (List<GioHangIT>)GioHang;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult ThanhToan(string shipName, string mobile, string address )
        {
            var giohang = new GioHang();
            giohang.NgayThang = DateTime.Now;
            giohang.DiaChi = address;
            giohang.SDT = mobile;
            giohang.TenNguoiDung = shipName;

           try
            {
                var id = new GioHangDao().Insert(giohang);
                var GioHang = (List<GioHangIT>)Session[GioHangSession];
                var ctghDao = new ChiTietGioHangDao();
                foreach (var it in GioHang)
                {
                    var ctgh = new ChiTietGioHang();
                    ctgh.MaGiay = it.Giay.MaGiay;
                    ctgh.MaGioHang = id;
                    ctgh.DonGia = it.Giay.DonGia;
                    ctgh.SoLuong = it.SoLuong;
                    ctghDao.Insert(ctgh);
                }
            }
            catch(Exception ex)
            {
                return Redirect("/loi-thanh-toan");
            }
            return Redirect("/hoan-thanh");
        }

        public ActionResult ThanhCong ()
        {
            return View();
        }

    }
}

