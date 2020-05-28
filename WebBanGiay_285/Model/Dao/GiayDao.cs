using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
   public class GiayDao
    {
        WebGiay db = null;
        public GiayDao()
        {
            db = new WebGiay();
        }
        public Giay ViewDetail(long MaGiay)
        {
            return db.Giays.Find(MaGiay);
        }
        public List<Giay> LienQuan(long MG)
        {
            var sp = db.Giays.Find(MG);
            return db.Giays.Where(x => x.MaGiay != MG && x.MaSanPham == sp.MaSanPham).ToList();
        }

        public List<Giay> ListGiaylQ(long MaSP)
        {
            var sp = db.Giays.Find(MaSP);
            return db.Giays.Where(x => x.MaSanPham != MaSP  && x.MaSanPham == sp.MaSanPham).ToList();
        }
    }
}
