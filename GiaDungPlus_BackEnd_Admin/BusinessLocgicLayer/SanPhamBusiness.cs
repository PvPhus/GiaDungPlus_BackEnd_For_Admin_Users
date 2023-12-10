using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;
using System.Reflection;

namespace BusinessLogicLayer
{
    public class SanPhamBusiness: ISanPhamBusiness
    {
        private ISanPhamRepository _res;
        public SanPhamBusiness(ISanPhamRepository res)
        {
            _res = res;
        }
        public SanPhamModel GetChiTietSanPham(int id)
        {
            return _res.GetChiTietSanPham(id);
        }
        public bool Create(SanPhamModel model)
        {
            return _res.Create(model);
        }
        public bool Update(SanPhamModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(SanPhamModel model)
        {
            return _res.Delete(model);
        }
    }
}