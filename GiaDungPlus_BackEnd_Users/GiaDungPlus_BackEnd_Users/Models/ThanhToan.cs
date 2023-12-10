using System;
using System.Collections.Generic;

namespace Api.GiaDungPlus_BackEnd_Users.Models;

public partial class ThanhToan
{
    public int MaThanhToan { get; set; }

    public int? MaDonHang { get; set; }

    public DateTime NgayThanhToan { get; set; }

    public decimal SoTienThanhToan { get; set; }

    public string? PhuongThucThanhToan { get; set; }

    public string? MaGiaoDich { get; set; }

    public bool? TrangThai { get; set; }

    public virtual DonHang? MaDonHangNavigation { get; set; }
}
