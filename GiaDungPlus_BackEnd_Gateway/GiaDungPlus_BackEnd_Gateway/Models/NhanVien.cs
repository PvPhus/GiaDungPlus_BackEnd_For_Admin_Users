using System;
using System.Collections.Generic;

namespace GiaDungPlus_BackEnd_Gateway.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDonBans = new HashSet<HoaDonBan>();
            HoaDonNhaps = new HashSet<HoaDonNhap>();
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        public int MaNhanVien { get; set; }
        public string? TenNhanVien { get; set; }
        public string? ChucVu { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? DiaChi { get; set; }
        public string? SoDienThoai { get; set; }

        public virtual ICollection<HoaDonBan> HoaDonBans { get; set; }
        public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
