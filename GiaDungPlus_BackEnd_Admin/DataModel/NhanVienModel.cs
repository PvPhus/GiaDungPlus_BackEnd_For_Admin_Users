using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class NhanVienModel
    {
        public int MaNhanVien { get; set; }

        public string? TenNhanVien { get; set; }

        public string? ChucVu { get; set; }

        public DateTime? NgaySinh { get; set; }

        public string? DiaChi { get; set; }

        public string? SoDienThoai { get; set; }
    }
}
