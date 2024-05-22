using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectWebQLBH.ModelFromDB
{
    [Table("tblCTDonhang")]
    public partial class TblCtdonhang
    {
        [Key]
        [Column("CT_ID")]
        public Guid CtId { get; set; }
        [Column("CT_Ma")]
        [StringLength(100)]
        public string? CtMa { get; set; }
        [Column("CT_DH_ID")]
        public Guid? CtDhId { get; set; }
        [Column("CT_SP_ID")]
        public Guid? CtSpId { get; set; }
        [Column("CT_GiaSP")]
        public double? CtGiaSp { get; set; }
        [Column("CT_Soluong")]
        public int? CtSoluong { get; set; }

        [ForeignKey(nameof(CtDhId))]
        [InverseProperty(nameof(TblDonhang.TblCtdonhangs))]
        public virtual TblDonhang? CtDh { get; set; }
        [ForeignKey(nameof(CtSpId))]
        [InverseProperty(nameof(TblSanpham.TblCtdonhangs))]
        public virtual TblSanpham? CtSp { get; set; }
    }
}
