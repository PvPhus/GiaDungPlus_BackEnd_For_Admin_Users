using System;
using System.Collections.Generic;

namespace Api.GiaDungPlus.Models;

public partial class SanPham
{
    public int MaSanPham { get; set; }

    public string TenSanPham { get; set; } = null!;

    public decimal Gia { get; set; }

    public string? MoTa { get; set; }

    public string? HinhAnh { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = new List<ChiTietSanPham>();

    public virtual ICollection<DanhGium> DanhGia { get; set; } = new List<DanhGium>();
}
