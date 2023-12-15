using System;
using System.Collections.Generic;

namespace Api.GiaDungPlus.Models;

public partial class NhanVien
{
    public int MaNhanVien { get; set; }

    public string? TenNhanVien { get; set; }

    public string? ChucVu { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    public string? SoDienThoai { get; set; }

    public virtual ICollection<HoaDonBan> HoaDonBans { get; set; } = new List<HoaDonBan>();

    public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; set; } = new List<HoaDonNhap>();

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
