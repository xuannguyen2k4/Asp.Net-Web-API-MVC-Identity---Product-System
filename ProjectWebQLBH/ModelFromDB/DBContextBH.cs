using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectWebQLBH.ModelFromDB
{
    public partial class DBContextBH : DbContext
    {
        public DBContextBH()
        {
        }

        public DBContextBH(DbContextOptions<DBContextBH> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCtdonhang> TblCtdonhangs { get; set; } = null!;
        public virtual DbSet<TblDonhang> TblDonhangs { get; set; } = null!;
        public virtual DbSet<TblDonviVc> TblDonviVcs { get; set; } = null!;
        public virtual DbSet<TblKhachhang> TblKhachhangs { get; set; } = null!;
        public virtual DbSet<TblNhacungcap> TblNhacungcaps { get; set; } = null!;
        public virtual DbSet<TblNhanvien> TblNhanviens { get; set; } = null!;
        public virtual DbSet<TblPhieunhap> TblPhieunhaps { get; set; } = null!;
        public virtual DbSet<TblPhieunhapCt> TblPhieunhapCts { get; set; } = null!;
        public virtual DbSet<TblSanpham> TblSanphams { get; set; } = null!;

        public override int SaveChanges()
        {
            UpdateCtnTongtien();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateCtnTongtien();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateCtnTongtien()
        {
            foreach (var entry in ChangeTracker.Entries<TblPhieunhapCt>())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdateTongtien();
                }
            }
        }

    }
}
