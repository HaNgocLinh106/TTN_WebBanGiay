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
        public Giay ViewDetail(long MaSP)
        {
            //return db.Giays.Find(MaGiay);
            var sp = db.SanPhams.Find(MaSP);
            //return db.Giays.Where(x => x.MaSanPham == sp.MaSanPham);
            return db.Giays.FirstOrDefault(x => x.MaSanPham == sp.MaSanPham);
        }
        public List<Giay> LienQuan(long MG)
        {
            var sp = db.Giays.Find(MG);
            return db.Giays.Where(x => x.MaGiay != MG && x.MaSanPham == sp.MaSanPham).ToList();
        }

        public List<Giay> ListGiaylQ(long MaSP)
        {
            var sp = db.SanPhams.Find(MaSP);
            return db.Giays.Where(x => x.MaSanPham == sp.MaSanPham).ToList();
        }

    }
}
