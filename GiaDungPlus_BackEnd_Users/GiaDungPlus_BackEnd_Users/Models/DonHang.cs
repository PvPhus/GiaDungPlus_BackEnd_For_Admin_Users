using System;
using System.Collections.Generic;

namespace Api.GiaDungPlus_BackEnd_Users.Models;

public partial class DonHang
{
    public int MaDonHang { get; set; }

    public int MaNguoiDung { get; set; }

    public DateTime NgayDatHang { get; set; }

    public decimal TongTien { get; set; }

    public bool? TrangThai { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual NguoiDung MaNguoiDungNavigation { get; set; } = null!;

    public virtual ICollection<ThanhToan> ThanhToans { get; set; } = new List<ThanhToan>();
}
