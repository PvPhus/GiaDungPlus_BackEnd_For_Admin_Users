using System;
using System.Collections.Generic;

namespace GiaDungPlus_BackEnd_Gateway.Models
{
    public partial class HoaDonNhap
    {
        public int MaHoaDonNhap { get; set; }
        public int? MaNhanVien { get; set; }
        public int? MaNhaCungCap { get; set; }
        public DateTime? NgayNhap { get; set; }
        public decimal? TongTien { get; set; }

        public virtual NhaCungCap? MaNhaCungCapNavigation { get; set; }
        public virtual NhanVien? MaNhanVienNavigation { get; set; }
    }
}
