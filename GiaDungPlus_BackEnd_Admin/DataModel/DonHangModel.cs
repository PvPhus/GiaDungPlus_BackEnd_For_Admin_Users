using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DonHangModel
    {
        public int MaDonHang { get; set; }

        public int MaNguoiDung { get; set; }

        public DateTime NgayDatHang { get; set; }

        public decimal TongTien { get; set; }

        public bool? TrangThai { get; set; }

        public List<ChiTietDonHangModel> list_json_chitietdonhang { get; set; }
    }
    public class ChiTietDonHangModel
    {
        public int MaChiTietDonHang { get; set; }

        public int MaDonHang { get; set; }

        public int MaSanPham { get; set; }

        public int SoLuong { get; set; }

        public decimal ThanhTien { get; set; }
    }
}
