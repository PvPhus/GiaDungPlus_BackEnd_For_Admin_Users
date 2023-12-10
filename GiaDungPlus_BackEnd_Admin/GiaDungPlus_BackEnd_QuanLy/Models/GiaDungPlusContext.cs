using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api.GiaDungPlus.Models;

public partial class GiaDungPlusContext : DbContext
{
    public GiaDungPlusContext()
    {
    }

    public GiaDungPlusContext(DbContextOptions<GiaDungPlusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }

    public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }

    public virtual DbSet<DanhGium> DanhGia { get; set; }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<Slide> Slides { get; set; }

    public virtual DbSet<ThanhToan> ThanhToans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PhongPhu\\SQLEXPRESS;Database=GiaDungPlus;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietDonHang>(entity =>
        {
            entity.HasKey(e => e.MaChiTietDonHang).HasName("PK__ChiTietD__4B0B45DDBB014D97");

            entity.ToTable("ChiTietDonHang");

            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaDonHangNavigation).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.MaDonHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDo__MaDon__2E1BDC42");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDo__MaSan__2F10007B");
        });

        modelBuilder.Entity<ChiTietSanPham>(entity =>
        {
            entity.HasKey(e => e.MaChiTiet).HasName("PK__ChiTietS__CDF0A114F83C4436");

            entity.ToTable("ChiTietSanPham");

            entity.Property(e => e.LoaiSanPham)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NhaSanXuat)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.XuatXu).HasMaxLength(50);

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietSa__MaSan__286302EC");
        });

        modelBuilder.Entity<DanhGium>(entity =>
        {
            entity.HasKey(e => e.MaDanhGia).HasName("PK__DanhGia__AA9515BF53FD77E4");

            entity.Property(e => e.NgayDanhGia).HasColumnType("datetime");
            entity.Property(e => e.NhanXet).HasMaxLength(250);

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.MaNguoiDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DanhGia__MaNguoi__32E0915F");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DanhGia__MaSanPh__31EC6D26");
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.MaDonHang).HasName("PK__DonHang__129584ADC818D775");

            entity.ToTable("DonHang");

            entity.Property(e => e.NgayDatHang).HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaNguoiDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DonHang__MaNguoi__2B3F6F97");
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNguoiDung).HasName("PK__NguoiDun__C539D76215628997");

            entity.ToTable("NguoiDung");

            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HoTen)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MatKhau)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSanPham).HasName("PK__SanPham__FAC7442D92C457CF");

            entity.ToTable("SanPham");

            entity.Property(e => e.Gia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.HinhAnh)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.TenSanPham).HasMaxLength(100);
        });

        modelBuilder.Entity<Slide>(entity =>
        {
            entity.HasKey(e => e.MaAnh).HasName("PK__Slide__356240DFEEA29BF9");

            entity.ToTable("Slide");

            entity.Property(e => e.MoTa).HasMaxLength(250);
            entity.Property(e => e.TieuDe).HasMaxLength(250);
        });

        modelBuilder.Entity<ThanhToan>(entity =>
        {
            entity.HasKey(e => e.MaThanhToan).HasName("PK__ThanhToa__D4B2584451F6B7AC");

            entity.ToTable("ThanhToan");

            entity.Property(e => e.MaGiaoDich)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NgayThanhToan).HasColumnType("datetime");
            entity.Property(e => e.PhuongThucThanhToan)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SoTienThanhToan).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaDonHangNavigation).WithMany(p => p.ThanhToans)
                .HasForeignKey(d => d.MaDonHang)
                .HasConstraintName("FK__ThanhToan__MaDon__35BCFE0A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
