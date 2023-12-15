using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AuthenticateModel
    {
        public int MaTaiKhoan { get; set; }
        [Required]
        public string? TenTaiKhoan { get; set; }
        [Required]
        public string? MatKhau { get; set; }

        public string? LoaiTaiKhoan { get; set; }

        public int? MaNhanVien { get; set; }

        public int? MaKhachHang { get; set; }
    }

    public class AppSettings
    {
        public string Secret { get; set; }

    }
}
