using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ViewModel;

namespace Model.Dao
{
    public class UserDao
    {
        WebGiay db = null;
        public UserDao()
        {
            db = new WebGiay();
        }

        public long Insert(NguoiDung entity)
        {
            db.NguoiDungs.Add(entity);
            db.SaveChanges();
            return entity.MaNguoiDung;
        }
       
        public bool Update(NguoiDung entity)
        {
            try
            {
                var user = db.NguoiDungs.Find(entity.MaNguoiDung);
                user.UserName = entity.UserName;
                if (!string.IsNullOrEmpty(entity.Pass))
                {
                    user.Pass = entity.Pass;
                }
                user.DiaChi = entity.DiaChi;
                user.SDT = entity.SDT;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
  
        public NguoiDung GetById(string userName)
        {
            return db.NguoiDungs.SingleOrDefault(x => x.UserName == userName);
        }
        public NguoiDung ViewDetail(int id)
        {
            return db.NguoiDungs.Find(id);
        }

        public bool Login(string userName, string passWord)
        {
            var result = db.NguoiDungs.Count(x => x.UserName == userName && x.Pass == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckUserName(string userName)
        {
            return db.NguoiDungs.Count(x => x.UserName == userName) > 0;
        }
        public bool CheckSDT(string sdt)
        {
            return db.NguoiDungs.Count(x => x.SDT == sdt) > 0;
        }

        public List<GioHangOFViewModel> ListBySDT(long MaGH)
        {
            var model = from a in db.GioHangs
                        join b in db.ChiTietGioHangs
                        on a.MaGioHang equals b.MaGioHang
                        where a.MaGioHang == MaGH
                        select new GioHangOFViewModel()
                        {
                            TenNguoiDung = a.TenNguoiDung,
                            DiaChi = a.DiaChi,
                            NgayThang = a.NgayThang,
                            MaGiay = b.MaGiay,
                            DonGia = b.DonGia,
                            SoLuong = b.SoLuong
                        };
            return model.ToList();
        }

        public List<NguoiDung> TimKiemND(string TenDangNhap)
        {
            return db.NguoiDungs.Where(x => x.UserName == TenDangNhap).ToList();
        }

        public List<GioHang> TaiKhoanND(string SDT)
        {
            return db.GioHangs.Where(x => x.SDT == SDT).ToList();
        }
    }
}
