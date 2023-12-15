using System;
using System.Collections.Generic;

namespace Api.GiaDungPlus.Models;

public partial class KhachHang
{
    public int MaKhachHang { get; set; }

    public string? TenKhachHang { get; set; }

    public string? DiaChi { get; set; }

    public string? SoDienThoai { get; set; }

    public virtual ICollection<HoaDonBan> HoaDonBans { get; set; } = new List<HoaDonBan>();

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
