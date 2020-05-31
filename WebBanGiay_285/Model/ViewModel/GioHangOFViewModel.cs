using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
   public class GioHangOFViewModel
    {
        public string TenNguoiDung { set; get; }
        public string DiaChi { set; get; }
        public long MaGioHang { set; get; }
        public long? MaGiay { set; get; }
        public int? DonGia { set; get; }
        public long? SoLuong { set; get; }
        public DateTime? NgayThang { set; get; }

    }
}
