using System;
using System.Collections.Generic;

namespace Api.GiaDungPlus.Models;

public partial class NguoiDung
{
    public int MaNguoiDung { get; set; }

    public string TenDangNhap { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string SoDienThoai { get; set; } = null!;

    public virtual ICollection<DanhGium> DanhGia { get; set; } = new List<DanhGium>();

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();
}
