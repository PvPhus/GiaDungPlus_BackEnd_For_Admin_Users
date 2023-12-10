using System;
using System.Collections.Generic;

namespace Api.GiaDungPlus_BackEnd_Users.Models;

public partial class DanhGium
{
    public int MaDanhGia { get; set; }

    public int MaSanPham { get; set; }

    public int MaNguoiDung { get; set; }

    public int XepHang { get; set; }

    public string? NhanXet { get; set; }

    public DateTime NgayDanhGia { get; set; }

    public virtual NguoiDung MaNguoiDungNavigation { get; set; } = null!;

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
