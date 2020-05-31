using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class SanPhamDao
    {
        WebGiay db = null;
        public SanPhamDao()
        {
            db = new WebGiay();
        }
        public List<SanPham> ListSP(int top)
        {
            return db.SanPhams.Take(top).ToList();
        }
        public SanPham ViewDetail( long id)
        {
            return db.SanPhams.Find(id);
        }
        public List<Giay> TimKiemSP(string TenGiay)
        {
            return db.Giays.Where(x => x.TenGiay == TenGiay).ToList();
        }

    }
}
