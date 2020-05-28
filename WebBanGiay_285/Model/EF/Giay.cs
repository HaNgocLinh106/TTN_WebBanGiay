namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Giay")]
    public partial class Giay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Giay()
        {
            ChiTietGioHangs = new HashSet<ChiTietGioHang>();
        }

        [Key]
        public long MaGiay { get; set; }

        [StringLength(250)]
        public string TenGiay { get; set; }

        [StringLength(50)]
        public string MetaTitle { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public int? DonGia { get; set; }

        [StringLength(20)]
        public string Mau { get; set; }

        public int? Size { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(10)]
        public string LinkAnh { get; set; }

        public bool? TrangThai { get; set; }

        public long? MaSanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
