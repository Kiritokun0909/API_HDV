using System;
using System.Collections.Generic;
using API_SinhVien.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_SinhVien.DbContexts;

public partial class SVContext : DbContext
{
    public SVContext()
    {
    }

    public SVContext(DbContextOptions<SVContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BangDiem> BangDiems { get; set; }

    public virtual DbSet<LopTinChi> LopTinChis { get; set; }

    public virtual DbSet<MonHoc> MonHocs { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BangDiem>(entity =>
        {
            entity.HasKey(e => e.MaBangDiem);

            entity.ToTable("BangDiem");

            entity.HasIndex(e => new { e.MaSv, e.MaLopTc }, "UK_BangDiem").IsUnique();

            entity.Property(e => e.MaBangDiem).ValueGeneratedNever();
            entity.Property(e => e.MaSv).HasColumnName("MaSV");

            entity.HasOne(d => d.MaLopTcNavigation).WithMany(p => p.BangDiems)
                .HasForeignKey(d => d.MaLopTc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BangDiem_LopTinChi");

            entity.HasOne(d => d.MaSvNavigation).WithMany(p => p.BangDiems)
                .HasForeignKey(d => d.MaSv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BangDiem_SinhVien");
        });

        modelBuilder.Entity<LopTinChi>(entity =>
        {
            entity.HasKey(e => e.MaLopTc);

            entity.ToTable("LopTinChi");

            entity.HasIndex(e => new { e.MaMh, e.Nam, e.Ky }, "UK_LopTinChi").IsUnique();

            entity.Property(e => e.MaLopTc).ValueGeneratedNever();

            entity.HasOne(d => d.MaMhNavigation).WithMany(p => p.LopTinChis)
                .HasForeignKey(d => d.MaMh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LopTinChi_MonHoc");
        });

        modelBuilder.Entity<MonHoc>(entity =>
        {
            entity.HasKey(e => e.MaMh);

            entity.ToTable("MonHoc");

            entity.Property(e => e.MaMh).ValueGeneratedNever();
            entity.Property(e => e.TenMh).HasMaxLength(50);
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.MaSv);

            entity.ToTable("SinhVien");

            entity.Property(e => e.MaSv)
                .ValueGeneratedNever()
                .HasColumnName("MaSV");
            entity.Property(e => e.Ho).HasMaxLength(20);
            entity.Property(e => e.MatKhau)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.Sdt)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.Ten).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
