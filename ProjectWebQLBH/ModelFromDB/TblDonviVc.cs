using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectWebQLBH.ModelFromDB
{
    [Table("tblDonviVC")]
    public partial class TblDonviVc
    {
        public TblDonviVc()
        {
            TblDonhangs = new HashSet<TblDonhang>();
        }

        [Key]
        [Column("VC_ID")]
        public Guid VcId { get; set; }
        [Column("VC_Ma")]
        [StringLength(100)]
        public string? VcMa { get; set; }
        [Column("VC_Ten")]
        [StringLength(100)]
        public string? VcTen { get; set; }
        [Column("VC_SĐT")]
        [StringLength(10)]
        [Unicode(false)]
        public string? VcSđt { get; set; }
        [Column("VC_Diachilienlac")]
        [StringLength(100)]
        public string? VcDiachilienlac { get; set; }

        [InverseProperty(nameof(TblDonhang.DhDvcc))]
        public virtual ICollection<TblDonhang> TblDonhangs { get; set; }
    }
}
