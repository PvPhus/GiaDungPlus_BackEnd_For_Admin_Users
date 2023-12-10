using System;
using System.Collections.Generic;

namespace Api.GiaDungPlus.Models;

public partial class ChiTietSanPham
{
    public int MaChiTiet { get; set; }

    public int MaSanPham { get; set; }

    public string LoaiSanPham { get; set; } = null!;

    public int SoLuongTrongKho { get; set; }

    public string? NhaSanXuat { get; set; }

    public string? XuatXu { get; set; }

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
