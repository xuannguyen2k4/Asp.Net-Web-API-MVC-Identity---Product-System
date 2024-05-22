using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectWebQLBH.ModelFromDB
{
    [Table("tblNhacungcap")]
    public partial class TblNhacungcap
    {
        public TblNhacungcap()
        {
            TblPhieunhapCts = new HashSet<TblPhieunhapCt>();
            TblPhieunhaps = new HashSet<TblPhieunhap>();
            TblSanphams = new HashSet<TblSanpham>();
        }

        [Key]
        [Column("CC_ID")]
        public Guid CcId { get; set; }
        [Column("CC_Ma")]
        [StringLength(100)]
        public string? CcMa { get; set; }
        [Column("CC_TenNCC")]
        [StringLength(100)]
        public string? CcTenNcc { get; set; }
        [Column("CC_Diachi")]
        [StringLength(100)]
        public string? CcDiachi { get; set; }
        [Column("CC_SĐT")]
        [StringLength(10)]
        [Unicode(false)]
        public string? CcSđt { get; set; }

        [InverseProperty(nameof(TblPhieunhapCt.CtnNcc))]
        public virtual ICollection<TblPhieunhapCt> TblPhieunhapCts { get; set; }
        [InverseProperty(nameof(TblPhieunhap.PnNcc))]
        public virtual ICollection<TblPhieunhap> TblPhieunhaps { get; set; }
        [InverseProperty(nameof(TblSanpham.SpCc))]
        public virtual ICollection<TblSanpham> TblSanphams { get; set; }
    }
}
