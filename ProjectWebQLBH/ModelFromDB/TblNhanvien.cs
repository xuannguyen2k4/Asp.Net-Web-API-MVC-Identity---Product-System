using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectWebQLBH.ModelFromDB
{
    [Table("tblNhanvien")]
    public partial class TblNhanvien
    {
        public TblNhanvien()
        {
            TblDonhangs = new HashSet<TblDonhang>();
            TblPhieunhaps = new HashSet<TblPhieunhap>();
        }

        [Key]
        [Column("NV_ID")]
        public Guid NvId { get; set; }
        [Column("NV_Ma")]
        [StringLength(100)]
        public string? NvMa { get; set; }
        [Column("NV_Ten")]
        [StringLength(100)]
        public string? NvTen { get; set; }
        [Column("NV_Diachi")]
        [StringLength(100)]
        public string? NvDiachi { get; set; }
        [Column("NV_Email")]
        [StringLength(100)]
        public string? NvEmail { get; set; }
        [Column("NV_SĐT")]
        [StringLength(10)]
        [Unicode(false)]
        public string? NvSđt { get; set; }
        [Column("NV_Ngaysinh", TypeName = "date")]
        public DateTime? NvNgaysinh { get; set; }
        [Column("NV_Ngaythamgia", TypeName = "date")]
        public DateTime? NvNgaythamgia { get; set; }
        [Column("NV_Matkhau")]
        [StringLength(50)]
        public string? NvMatkhau { get; set; }
        [Column("NV_Gioitinh")]
        [StringLength(10)]
        public string? NvGioitinh { get; set; }

        [InverseProperty(nameof(TblDonhang.DhNv))]
        public virtual ICollection<TblDonhang> TblDonhangs { get; set; }
        [InverseProperty(nameof(TblPhieunhap.PnNv))]
        public virtual ICollection<TblPhieunhap> TblPhieunhaps { get; set; }
    }
}
