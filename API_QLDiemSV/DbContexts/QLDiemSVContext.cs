using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using API_QLDiemSV.Entities;

namespace API_QLDiemSV.DbContexts;

public partial class QLDiemSVContext : DbContext
{
    public QLDiemSVContext()
    {
    }

    public QLDiemSVContext(DbContextOptions<QLDiemSVContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BangDiem> BangDiems { get; set; }

    public virtual DbSet<GiangVien> GiangViens { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<LopSv> LopSvs { get; set; }

    public virtual DbSet<LopTinChi> LopTinChis { get; set; }

    public virtual DbSet<MonHoc> MonHocs { get; set; }

    public virtual DbSet<Quyen> Quyens { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BangDiem>(entity =>
        {
            entity.HasKey(e => e.MaBangDiem);

            entity.ToTable("BangDiem");

            entity.HasIndex(e => new { e.MaLopTc, e.MaSv }, "UX_BangDiem").IsUnique();

            entity.Property(e => e.MaBangDiem).ValueGeneratedNever();
            entity.Property(e => e.MaLopTc).HasColumnName("MaLopTC");
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

        modelBuilder.Entity<GiangVien>(entity =>
        {
            entity.HasKey(e => e.MaGv);

            entity.ToTable("GiangVien");

            entity.Property(e => e.MaGv)
                .ValueGeneratedNever()
                .HasColumnName("MaGV");
            entity.Property(e => e.Ho).HasMaxLength(20);
            entity.Property(e => e.MatKhau).HasMaxLength(75);
            entity.Property(e => e.Sdt)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.Ten).HasMaxLength(10);

            entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.GiangViens)
                .HasForeignKey(d => d.MaKhoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GiangVien_Khoa");

            entity.HasOne(d => d.MaQuyenNavigation).WithMany(p => p.GiangViens)
                .HasForeignKey(d => d.MaQuyen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GiangVien_Quyen");
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.MaKhoa);

            entity.ToTable("Khoa");

            entity.Property(e => e.MaKhoa).ValueGeneratedNever();
            entity.Property(e => e.TenKhoa).HasMaxLength(50);
        });

        modelBuilder.Entity<LopSv>(entity =>
        {
            entity.HasKey(e => e.MaLopSv).HasName("PK_LopSV");

            entity.ToTable("LopSv");

            entity.Property(e => e.MaLopSv)
                .ValueGeneratedNever()
                .HasColumnName("MaLopSV");
            entity.Property(e => e.TenLopSv)
                .HasMaxLength(50)
                .HasColumnName("TenLopSV");

            entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.LopSvs)
                .HasForeignKey(d => d.MaKhoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LopSV_Khoa");
        });

        modelBuilder.Entity<LopTinChi>(entity =>
        {
            entity.HasKey(e => e.MaLopTc);

            entity.ToTable("LopTinChi");

            entity.HasIndex(e => new { e.MaMh, e.Nam, e.Ky }, "UX_LopTinChi").IsUnique();

            entity.Property(e => e.MaLopTc)
                .ValueGeneratedNever()
                .HasColumnName("MaLopTC");
            entity.Property(e => e.MaMh).HasColumnName("MaMH");

            entity.HasOne(d => d.MaMhNavigation).WithMany(p => p.LopTinChis)
                .HasForeignKey(d => d.MaMh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LopTinChi_MonHoc");
        });

        modelBuilder.Entity<MonHoc>(entity =>
        {
            entity.HasKey(e => e.MaMh);

            entity.ToTable("MonHoc");

            entity.Property(e => e.MaMh)
                .ValueGeneratedNever()
                .HasColumnName("MaMH");
            entity.Property(e => e.SoTc).HasColumnName("SoTC");
            entity.Property(e => e.TenMh)
                .HasMaxLength(50)
                .HasColumnName("TenMH");
            entity.Property(e => e.TsbaiTap).HasColumnName("TSBaiTap");
            entity.Property(e => e.TschuyenCan).HasColumnName("TSChuyenCan");
            entity.Property(e => e.TskiemTra).HasColumnName("TSKiemTra");
            entity.Property(e => e.Tsthi).HasColumnName("TSThi");
            entity.Property(e => e.TsthucHanh).HasColumnName("TSThucHanh");
        });

        modelBuilder.Entity<Quyen>(entity =>
        {
            entity.HasKey(e => e.MaQuyen);

            entity.ToTable("Quyen");

            entity.Property(e => e.MaQuyen).ValueGeneratedNever();
            entity.Property(e => e.TenQuyen).HasMaxLength(50);
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.MaSv);

            entity.ToTable("SinhVien");

            entity.Property(e => e.MaSv)
                .ValueGeneratedNever()
                .HasColumnName("MaSV");
            entity.Property(e => e.Ho).HasMaxLength(20);
            entity.Property(e => e.MaLopSv).HasColumnName("MaLopSV");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasDefaultValueSql("('123456')");
            entity.Property(e => e.Sdt)
                .HasMaxLength(14)
                .HasColumnName("SDT");
            entity.Property(e => e.Ten).HasMaxLength(10);

            entity.HasOne(d => d.MaLopSvNavigation).WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.MaLopSv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SinhVien_LopSV");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
