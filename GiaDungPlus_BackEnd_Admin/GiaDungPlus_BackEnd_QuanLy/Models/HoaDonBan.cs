using System;
using System.Collections.Generic;

namespace Api.GiaDungPlus.Models;

public partial class HoaDonBan
{
    public int MaHoaDonBan { get; set; }

    public int? MaNhanVien { get; set; }

    public int? MaKhachHang { get; set; }

    public DateTime? NgayBan { get; set; }

    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
