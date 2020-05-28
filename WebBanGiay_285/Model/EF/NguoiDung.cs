namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            GioHangs = new HashSet<GioHang>();
            PhanHois = new HashSet<PhanHoi>();
        }

        [Key]
        public int MaNguoiDung { get; set; }

        [StringLength(250)]
        public string TenNguoiDung { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(500)]
        public string DiaChi { get; set; }

        [StringLength(250)]
        public string UserName { get; set; }

        [StringLength(10)]
        public string Pass { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanHoi> PhanHois { get; set; }
    }
}
