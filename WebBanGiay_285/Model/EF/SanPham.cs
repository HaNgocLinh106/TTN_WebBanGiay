namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            Anhs = new HashSet<Anh>();
            Giays = new HashSet<Giay>();
        }

        [Key]
        public long MaSanPham { get; set; }

        [StringLength(100)]
        public string TenSanPham { get; set; }

        internal List<SanPham> ToList()
        {
            throw new NotImplementedException();
        }

        [StringLength(50)]
        public string MetaTitle { get; set; }

        public int? DonGia { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        public bool? TrangThai { get; set; }

        public long? MaDanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anh> Anhs { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Giay> Giays { get; set; }
    }
}
