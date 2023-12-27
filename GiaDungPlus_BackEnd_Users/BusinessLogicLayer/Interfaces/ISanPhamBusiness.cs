using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace BusinessLogicLayer.Interfaces
{
    public partial interface ISanPhamBusiness
    {
        List<DoGiaDungModel> GetAllProducts();
        List<LoaiDoGiaDung> GetAllCategory();
        public List<DoGiaDungModel> SearchProducts(int pageIndex, int pageSize, out long total, string ten_sanpham);
    }
}
