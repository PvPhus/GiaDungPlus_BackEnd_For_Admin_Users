using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface ISanPhamBusiness
    {
        SanPhamModel GetChiTietSanPham(int id);
        bool Create(SanPhamModel model);
        bool Update(SanPhamModel model);
        bool Delete(SanPhamModel model);
    }
}
