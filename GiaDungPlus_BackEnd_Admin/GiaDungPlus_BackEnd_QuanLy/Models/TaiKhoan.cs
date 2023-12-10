using System;
using System.Collections.Generic;

namespace Api.GiaDungPlus.Models;

public partial class TaiKhoan
{
    public int MaTaiKhoan { get; set; }

    public string? HoVaTen { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public string? MatKhau { get; set; }
}
