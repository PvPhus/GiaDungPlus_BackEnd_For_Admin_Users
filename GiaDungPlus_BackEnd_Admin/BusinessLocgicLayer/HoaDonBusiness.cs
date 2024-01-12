using BusinessLogicLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class HoaDonBusiness: IHoaDonBusiness
    {
        private IHoaDonRepository _res;
        public HoaDonBusiness(IHoaDonRepository res)
        {
            _res = res;
        }
        public HoaDonBanModel GetDataByIDBan(int id)
        {
            return _res.GetDataByIDBan(id);
        }
        public List<HoaDonBanModel> GetAllBan()
        {
            return _res.GetAllBan();
        }
        public bool CreateBan(HoaDonBanModel model)
        {
            return _res.CreateBan(model);
        }
        public bool UpdateBan(HoaDonBanModel model)
        {
            return _res.UpdateBan(model);
        }
        public bool DeleteBan(HoaDonBanModel model)
        {
            return _res.DeleteBan(model);
        }

        public HoaDonNhapModel GetDataByIDNhap(int id)
        {
            return _res.GetDataByIDNhap(id);
        }
        public List<HoaDonNhapModel> GetAllNhap()
        {
            return _res.GetAllNhap();
        }
        public bool CreateNhap(HoaDonNhapModel model)
        {
            return _res.CreateNhap(model);
        }
        public bool UpdateNhap(HoaDonNhapModel model)
        {
            return _res.UpdateNhap(model);
        }
        public bool DeleteNhap(HoaDonNhapModel model)
        {
            return _res.DeleteNhap(model);
        }
    }
}
