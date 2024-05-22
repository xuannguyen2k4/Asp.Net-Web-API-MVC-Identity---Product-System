using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectWebQLBH.ModelFromDB
{
    [Table("tblDonhang")]
    public partial class TblDonhang
    {
        public TblDonhang()
        {
            TblCtdonhangs = new HashSet<TblCtdonhang>();
        }

        [Key]
        [Column("DH_ID")]
        public Guid DhId { get; set; }
        [Column("DH_Ma")]
        [StringLength(100)]
        public string? DhMa { get; set; }
        [Column("DH_KH_ID")]
        public Guid? DhKhId { get; set; }
        [Column("DH_DVCC_ID")]
        public Guid? DhDvccId { get; set; }
        [Column("DH_NgayDatHang", TypeName = "datetime")]
        public DateTime? DhNgayDatHang { get; set; }
        [Column("DH_TrangThai")]
        [StringLength(100)]
        public string? DhTrangThai { get; set; }
        [Column("DH_NgayDuKien", TypeName = "datetime")]
        public DateTime? DhNgayDuKien { get; set; }
        [Column("DH_NgayThuc", TypeName = "datetime")]
        public DateTime? DhNgayThuc { get; set; }
        [Column("DH_NV_ID")]
        public Guid? DhNvId { get; set; }

        [ForeignKey(nameof(DhDvccId))]
        [InverseProperty(nameof(TblDonviVc.TblDonhangs))]
       
        public virtual TblDonviVc? DhDvcc { get; set; }
        [ForeignKey(nameof(DhKhId))]
        [InverseProperty(nameof(TblKhachhang.TblDonhangs))]
      
        public virtual TblKhachhang? DhKh { get; set; }
        [ForeignKey(nameof(DhNvId))]
        [InverseProperty(nameof(TblNhanvien.TblDonhangs))]
      
        public virtual TblNhanvien? DhNv { get; set; }
        [InverseProperty(nameof(TblCtdonhang.CtDh))]
        public virtual ICollection<TblCtdonhang> TblCtdonhangs { get; set; }
    }
}
