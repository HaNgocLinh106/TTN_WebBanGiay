namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GioHang()
        {
            ChiTietGioHangs = new HashSet<ChiTietGioHang>();
        }

        [Key]
        public long MaGioHang { get; set; }

        public int? MaNguoiDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThang { get; set; }

        [StringLength(250)]
        public string HinhThucThanhToan { get; set; }

        [StringLength(250)]
        public string TenNguoiDung { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(500)]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
