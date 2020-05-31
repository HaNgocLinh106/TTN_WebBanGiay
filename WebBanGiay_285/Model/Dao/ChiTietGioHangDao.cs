using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
   public class ChiTietGioHangDao
    {
        WebGiay db = null;
        public ChiTietGioHangDao()
        {
            db = new WebGiay();
        }
        public bool Insert(ChiTietGioHang ctgh)
        {
            try
            {
                db.ChiTietGioHangs.Add(ctgh);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
