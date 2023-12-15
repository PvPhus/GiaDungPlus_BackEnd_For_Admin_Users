using System;
using System.Collections.Generic;

namespace Api.GiaDungPlus.Models;

public partial class LoaiDoGiaDung
{
    public int MaLoai { get; set; }

    public string? TenLoai { get; set; }

    public int? SoLuongLoaiTon { get; set; }

    public virtual ICollection<DoGiaDung> DoGiaDungs { get; set; } = new List<DoGiaDung>();
}
