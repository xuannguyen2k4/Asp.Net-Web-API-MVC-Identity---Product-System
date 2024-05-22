using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectWebQLBH.ModelFromDB
{
    [Table("tblKhachhang")]
    public partial class TblKhachhang
    {
        public TblKhachhang()
        {
            TblDonhangs = new HashSet<TblDonhang>();
        }

        [Key]
        [Column("KH_ID")]
        public Guid KhId { get; set; }
        [Column("KH_Ma")]
        [StringLength(100)]
        public string? KhMa { get; set; }
        [Column("KH_Ten")]
        [StringLength(100)]
        public string? KhTen { get; set; }
        [Column("KH_Diachi")]
        [StringLength(100)]
        public string? KhDiachi { get; set; }
        [Column("KH_Email")]
        [StringLength(100)]
        public string? KhEmail { get; set; }
        [Column("KH_SĐT")]
        [StringLength(10)]
        [Unicode(false)]
        public string? KhSđt { get; set; }
        [Column("KH_Ngaysinh", TypeName = "date")]
        public DateTime? KhNgaysinh { get; set; }
        [Column("KH_Ngaythamgia", TypeName = "date")]
        public DateTime? KhNgaythamgia { get; set; }
        [Column("KH_Matkhau")]
        [StringLength(50)]
        public string? KhMatkhau { get; set; }
        [Column("KH_Gioitinh")]
        [StringLength(10)]
        public string? KhGioitinh { get; set; }

        [InverseProperty(nameof(TblDonhang.DhKh))]
        public virtual ICollection<TblDonhang> TblDonhangs { get; set; }
    }
}
