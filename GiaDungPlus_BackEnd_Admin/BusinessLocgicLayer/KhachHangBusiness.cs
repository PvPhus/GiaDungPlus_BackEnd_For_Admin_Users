using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class KhachHangBusiness: IKhachHangBusiness
    {
        private IKhachHangRepository _res;
        public KhachHangBusiness(IKhachHangRepository res)
        {
            _res = res;
        }
        public KhachHangModel GetDataByID(int id)
        {
            return _res.GetDataByID(id);
        }
        public bool Create(KhachHangModel model)
        {
            return _res.Create(model);
        }
        public bool Update(KhachHangModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(KhachHangModel model)
        {
            return _res.Delete(model);
        }
        public List<KhachHangModel> SearchKhachHang(int pageIndex, int pageSize, out long total, string nameKH, string diaChi)
        {
            return _res.SearchKhachHang(pageIndex, pageSize, out total, nameKH, diaChi);
        }
    }
}
