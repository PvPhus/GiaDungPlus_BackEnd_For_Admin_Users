using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api.GiaDungPlus_BackEnd_Users.Models;

public partial class GiaDungPlusAfterContext : DbContext
{
    public GiaDungPlusAfterContext()
    {
    }

    public GiaDungPlusAfterContext(DbContextOptions<GiaDungPlusAfterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; }

    public virtual DbSet<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; }

    public virtual DbSet<DoGiaDung> DoGiaDungs { get; set; }

    public virtual DbSet<HoaDonBan> HoaDonBans { get; set; }

    public virtual DbSet<HoaDonNhap> HoaDonNhaps { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiDoGiaDung> LoaiDoGiaDungs { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<Slide> Slides { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PhongPhu\\SQLEXPRESS;Database=GiaDungPlusAfter;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietHoaDonBan>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ChiTietHoaDonBan");

            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaHoaDonBanNavigation).WithMany()
                .HasForeignKey(d => d.MaHoaDonBan)
                .HasConstraintName("FK__ChiTietHo__MaHoa__1CBC4616");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany()
                .HasForeignKey(d => d.MaSanPham)
                .HasConstraintName("FK__ChiTietHo__MaSan__1DB06A4F");
        });

        modelBuilder.Entity<ChiTietHoaDonNhap>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ChiTietHoaDonNhap");

            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaHoaDonNhapNavigation).WithMany()
                .HasForeignKey(d => d.MaHoaDonNhap)
                .HasConstraintName("FK__ChiTietHo__MaHoa__282DF8C2");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany()
                .HasForeignKey(d => d.MaSanPham)
                .HasConstraintName("FK__ChiTietHo__MaSan__29221CFB");
        });

        modelBuilder.Entity<DoGiaDung>(entity =>
        {
            entity.HasKey(e => e.MaSanPham).HasName("PK__DoGiaDun__FAC7442DAE3BDE6F");

            entity.ToTable("DoGiaDung");

            entity.Property(e => e.MaSanPham).ValueGeneratedNever();
            entity.Property(e => e.Gia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.HinhAnh).HasMaxLength(500);
            entity.Property(e => e.TenSanPham).HasMaxLength(255);

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.DoGiaDungs)
                .HasForeignKey(d => d.MaLoai)
                .HasConstraintName("FK__DoGiaDung__MaLoa__14270015");
        });

        modelBuilder.Entity<HoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaHoaDonBan).HasName("PK__HoaDonBa__6A50CA8A9B7AC6CC");

            entity.ToTable("HoaDonBan");

            entity.Property(e => e.MaHoaDonBan).ValueGeneratedNever();
            entity.Property(e => e.NgayBan).HasColumnType("date");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__HoaDonBan__MaKha__10566F31");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__HoaDonBan__MaNha__0F624AF8");
        });

        modelBuilder.Entity<HoaDonNhap>(entity =>
        {
            entity.HasKey(e => e.MaHoaDonNhap).HasName("PK__HoaDonNh__448838B545E9B895");

            entity.ToTable("HoaDonNhap");

            entity.Property(e => e.MaHoaDonNhap).ValueGeneratedNever();
            entity.Property(e => e.NgayNhap).HasColumnType("date");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaNhaCungCapNavigation).WithMany(p => p.HoaDonNhaps)
                .HasForeignKey(d => d.MaNhaCungCap)
                .HasConstraintName("FK__HoaDonNha__MaNha__25518C17");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.HoaDonNhaps)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__HoaDonNha__MaNha__2645B050");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KhachHan__88D2F0E5C3DA0DF8");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKhachHang).ValueGeneratedNever();
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TenKhachHang).HasMaxLength(255);
        });

        modelBuilder.Entity<LoaiDoGiaDung>(entity =>
        {
            entity.HasKey(e => e.MaLoai).HasName("PK__LoaiDoGi__730A5759CC7C746C");

            entity.ToTable("LoaiDoGiaDung");

            entity.Property(e => e.MaLoai).ValueGeneratedNever();
            entity.Property(e => e.TenLoai).HasMaxLength(50);
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNhaCungCap).HasName("PK__NhaCungC__53DA9205DA041666");

            entity.ToTable("NhaCungCap");

            entity.Property(e => e.MaNhaCungCap).ValueGeneratedNever();
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TenNhaCungCap).HasMaxLength(255);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA47E571D96B");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNhanVien).ValueGeneratedNever();
            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TenNhanVien).HasMaxLength(255);
        });

        modelBuilder.Entity<Slide>(entity =>
        {
            entity.HasKey(e => e.MaAnh).HasName("PK__Slide__356240DFDD649C76");

            entity.ToTable("Slide");

            entity.Property(e => e.MoTa).HasMaxLength(250);
            entity.Property(e => e.TieuDe).HasMaxLength(250);
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaTaiKhoan).HasName("PK__TaiKhoan__AD7C652947B2E63D");

            entity.ToTable("TaiKhoan");

            entity.HasIndex(e => e.TenTaiKhoan, "UQ__TaiKhoan__B106EAF8BB5E70B5").IsUnique();

            entity.Property(e => e.MaTaiKhoan).ValueGeneratedNever();
            entity.Property(e => e.LoaiTaiKhoan).HasMaxLength(20);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.TenTaiKhoan).HasMaxLength(50);

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__TaiKhoan__MaKhac__308E3499");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__TaiKhoan__MaNhan__2F9A1060");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
