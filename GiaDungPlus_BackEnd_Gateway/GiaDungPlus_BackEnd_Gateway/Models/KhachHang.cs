using System;
using System.Collections.Generic;

namespace GiaDungPlus_BackEnd_Gateway.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDonBans = new HashSet<HoaDonBan>();
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        public int MaKhachHang { get; set; }
        public string? TenKhachHang { get; set; }
        public string? DiaChi { get; set; }
        public string? SoDienThoai { get; set; }

        public virtual ICollection<HoaDonBan> HoaDonBans { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
