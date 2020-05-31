using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class GioHangDao
    {
        WebGiay db = null;
        public GioHangDao()
        {
            db = new WebGiay();
        }
        public long Insert(GioHang giohang)
        {
            db.GioHangs.Add(giohang);
            db.SaveChanges();
            return giohang.MaGioHang;
        }
    }
}
