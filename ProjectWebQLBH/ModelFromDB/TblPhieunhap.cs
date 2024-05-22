using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectWebQLBH.ModelFromDB
{
    [Table("tblPhieunhap")]
    public partial class TblPhieunhap
    {
        public TblPhieunhap()
        {
            TblPhieunhapCts = new HashSet<TblPhieunhapCt>();
        }

        [Key]
        [Column("PN_ID")]
        public Guid PnId { get; set; }
        [Column("PN_Ma")]
        [StringLength(100)]
        public string? PnMa { get; set; }
        [Column("PN_Ngaynhap", TypeName = "date")]
        public DateTime? PnNgaynhap { get; set; }
        [Column("PN_Tien")]
        public double? PnTien { get; set; }
        [Column("PN_NCC_ID")]
        public Guid? PnNccId { get; set; }
        [Column("PN_NV_ID")]
        public Guid? PnNvId { get; set; }

        [ForeignKey(nameof(PnNccId))]
        [InverseProperty(nameof(TblNhacungcap.TblPhieunhaps))]
        
        public virtual TblNhacungcap? PnNcc { get; set; }
        [ForeignKey(nameof(PnNvId))]
        [InverseProperty(nameof(TblNhanvien.TblPhieunhaps))]
        
        public virtual TblNhanvien? PnNv { get; set; }
        [InverseProperty(nameof(TblPhieunhapCt.CtnPn))]
        public virtual ICollection<TblPhieunhapCt> TblPhieunhapCts { get; set; }
    }
}
