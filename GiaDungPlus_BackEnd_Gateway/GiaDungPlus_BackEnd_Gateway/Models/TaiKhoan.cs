using System;
using System.Collections.Generic;

namespace GiaDungPlus_BackEnd_Gateway.Models
{
    public partial class TaiKhoan
    {
        public int MaTaiKhoan { get; set; }
        public string? TenTaiKhoan { get; set; }
        public string? MatKhau { get; set; }
        public string? LoaiTaiKhoan { get; set; }
        public int? MaNhanVien { get; set; }
        public int? MaKhachHang { get; set; }

        public virtual KhachHang? MaKhachHangNavigation { get; set; }
        public virtual NhanVien? MaNhanVienNavigation { get; set; }
    }
}
