﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DoGiaDungModel
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public decimal Gia { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }
        public int MaLoai { get; set; }
    }
    public class LoaiDoGiaDung
    {
        public int MaLoai { set; get; }
        public string TenLoai { set; get; }
        public int SoLuongLoaiTon { get; set; }
    }
}
