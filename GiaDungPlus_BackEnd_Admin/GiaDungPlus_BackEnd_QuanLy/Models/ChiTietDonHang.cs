﻿using System;
using System.Collections.Generic;

namespace Api.GiaDungPlus.Models;

public partial class ChiTietDonHang
{
    public int MaChiTietDonHang { get; set; }

    public int MaDonHang { get; set; }

    public int MaSanPham { get; set; }

    public int SoLuong { get; set; }

    public decimal ThanhTien { get; set; }

    public virtual DonHang MaDonHangNavigation { get; set; } = null!;

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
