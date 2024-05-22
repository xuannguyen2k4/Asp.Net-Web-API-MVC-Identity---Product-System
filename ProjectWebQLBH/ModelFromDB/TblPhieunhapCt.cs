using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectWebQLBH.ModelFromDB
{
    [Table("tblPhieunhapCT")]
    public partial class TblPhieunhapCt
    {
        [Key]
        [Column("CTN_ID")]
        public Guid CtnId { get; set; }
        [Column("CTN_Ma")]
        [StringLength(100)]
        public string? CtnMa { get; set; }
        [Column("CTN_Gianhap")]
        public double? CtnGianhap { get; set; }
        [Column("CTN_Soluong")]
        public int? CtnSoluong { get; set; }
        [Column("CTN_Tongtien")]
        public double? CtnTongtien { get; set; }
        [Column("CTN_SP_ID")]
        public Guid? CtnSpId { get; set; }
        [Column("CTN_NCC_ID")]
        public Guid? CtnNccId { get; set; }
        [Column("CTN_PN_ID")]
        public Guid? CtnPnId { get; set; }

        [ForeignKey(nameof(CtnNccId))]
        [InverseProperty(nameof(TblNhacungcap.TblPhieunhapCts))]
        public virtual TblNhacungcap? CtnNcc { get; set; }
        
        [ForeignKey(nameof(CtnPnId))]
        [InverseProperty(nameof(TblPhieunhap.TblPhieunhapCts))]
        public virtual TblPhieunhap? CtnPn { get; set; }
        
        [ForeignKey(nameof(CtnSpId))]
        [InverseProperty(nameof(TblSanpham.TblPhieunhapCts))]
        public virtual TblSanpham? CtnSp { get; set; }

        // Phương thức để tính toán tổng tiền
        public void UpdateTongtien()
        {
            if (CtnGianhap.HasValue && CtnSoluong.HasValue)
            {
                CtnTongtien = CtnGianhap.Value * CtnSoluong.Value;
            }
        }
    }
}
