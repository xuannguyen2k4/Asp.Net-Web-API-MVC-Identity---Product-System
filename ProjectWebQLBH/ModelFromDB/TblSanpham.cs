using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectWebQLBH.ModelFromDB
{
    [Table("tblSanpham")]
    public partial class TblSanpham
    {
        public TblSanpham()
        {
            TblCtdonhangs = new HashSet<TblCtdonhang>();
            TblPhieunhapCts = new HashSet<TblPhieunhapCt>();
        }

        [Key]
        [Column("SP_ID")]
        public Guid SpId { get; set; }
        [Column("SP_Ma")]
        [StringLength(100)]
        public string? SpMa { get; set; }
        [Column("SP_TenSP")]
        [StringLength(100)]
        public string? SpTenSp { get; set; }
        [Column("SP_Mota")]
        [StringLength(100)]
        public string? SpMota { get; set; }
        [Column("SP_Donvi")]
        [StringLength(100)]
        public string? SpDonvi { get; set; }
        [Column("SP_Giaban")]
        public double? SpGiaban { get; set; }
        [Column("SP_NSX", TypeName = "date")]
        public DateTime? SpNsx { get; set; }
        [Column("SP_HSD", TypeName = "date")]
        public DateTime? SpHsd { get; set; }
        [Column("SP_CC_ID")]
        public Guid? SpCcId { get; set; }

        [ForeignKey(nameof(SpCcId))]
        [InverseProperty(nameof(TblNhacungcap.TblSanphams))]
        public virtual TblNhacungcap? SpCc { get; set; }
        [InverseProperty(nameof(TblCtdonhang.CtSp))]
        public virtual ICollection<TblCtdonhang> TblCtdonhangs { get; set; }
        [InverseProperty(nameof(TblPhieunhapCt.CtnSp))]
        public virtual ICollection<TblPhieunhapCt> TblPhieunhapCts { get; set; }
    }
}
