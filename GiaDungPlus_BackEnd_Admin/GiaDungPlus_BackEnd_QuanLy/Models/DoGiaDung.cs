using System;
using System.Collections.Generic;

namespace Api.GiaDungPlus.Models;

public partial class DoGiaDung
{
    public int MaSanPham { get; set; }

    public string? TenSanPham { get; set; }

    public decimal? Gia { get; set; }

    public string? MoTa { get; set; }

    public string? HinhAnh { get; set; }

    public int? MaLoai { get; set; }

    public virtual LoaiDoGiaDung? MaLoaiNavigation { get; set; }
}
