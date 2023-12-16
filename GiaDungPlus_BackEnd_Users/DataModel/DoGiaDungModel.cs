using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DoGiaDungModel
    {
        public int MaSanPham {  get; set; }
        public String TenSanPham { get; set; }
        public decimal Gia { get; set; }
        public String MoTa { get; set; }
        public String HinhAnh { get; set; }    
        public int MaLoai { get; set; }
    }
}
