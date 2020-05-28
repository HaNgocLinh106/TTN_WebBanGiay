using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class DanhMucDao
    {
        WebGiay db = null;
        public DanhMucDao()
        {
            db = new WebGiay();
        }

        public List<DanhMuc> ListAll()
        {
            return db.DanhMucs.ToList();
        }
        public SanPham ViewDetail(long MaDanhMuc)
        {
            return db.SanPhams.Find(MaDanhMuc);
        }
        public List<SanPham> ListAllSP(long MaDanhMuc)
        {
            var sp = db.SanPhams.Find(MaDanhMuc);
            return db.SanPhams.Where(x => x.MaDanhMuc == sp.MaDanhMuc).ToList();
        }
    }
}
