using System;
using System.Collections.Generic;

namespace GiaDungPlus_BackEnd_Gateway.Models
{
    public partial class LoaiDoGiaDung
    {
        public LoaiDoGiaDung()
        {
            DoGiaDungs = new HashSet<DoGiaDung>();
        }

        public int MaLoai { get; set; }
        public string? TenLoai { get; set; }
        public int? SoLuongLoaiTon { get; set; }

        public virtual ICollection<DoGiaDung> DoGiaDungs { get; set; }
    }
}
