using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class HoaDonNhapModel
    {
        public int MaHoaDonNhap { get; set; }

        public int? MaNhanVien { get; set; }

        public int? MaNhaCungCap { get; set; }

        public DateTime? NgayNhap { get; set; }

        public decimal? TongTien { get; set; }
        public List<ChiTietHoaDonNhapModel> list_json_chitiethoadonnhap { get; set; }
    }
    public class ChiTietHoaDonNhapModel
    {
        public int? MaHoaDonNhap { get; set; }

        public int? MaSanPham { get; set; }

        public int? SoLuong { get; set; }

        public decimal? DonGia { get; set; }

        public decimal? ThanhTien { get; set; }
    }

    public class HoaDonBanModel
    {
        public int MaHoaDonBan { get; set; }

        public int? MaNhanVien { get; set; }

        public int? MaKhachHang { get; set; }

        public DateTime? NgayBan { get; set; }

        public List<ChiTietHoaDonBanModel> list_json_chitiethoadonban { get; set; }
    }
    public class ChiTietHoaDonBanModel
    {
        public int? MaHoaDonBan { get; set; }

        public int? MaSanPham { get; set; }

        public int? SoLuong { get; set; }

        public decimal? DonGia { get; set; }

        public decimal? ThanhTien { get; set; }
    }
}
