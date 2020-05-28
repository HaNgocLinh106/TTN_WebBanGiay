namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Anh")]
    public partial class Anh
    {
        [Key]
        public int MaAnh { get; set; }

        [StringLength(1000)]
        public string LinkAnh { get; set; }

        public long? MaSanPham { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
