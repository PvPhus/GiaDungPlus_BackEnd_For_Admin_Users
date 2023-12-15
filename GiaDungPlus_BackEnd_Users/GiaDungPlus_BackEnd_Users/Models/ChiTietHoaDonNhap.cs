using System;
using System.Collections.Generic;

namespace Api.GiaDungPlus_BackEnd_Users.Models;

public partial class ChiTietHoaDonNhap
{
    public int? MaHoaDonNhap { get; set; }

    public int? MaSanPham { get; set; }

    public int? SoLuong { get; set; }

    public decimal? DonGia { get; set; }

    public decimal? ThanhTien { get; set; }

    public virtual HoaDonNhap? MaHoaDonNhapNavigation { get; set; }

    public virtual DoGiaDung? MaSanPhamNavigation { get; set; }
}
