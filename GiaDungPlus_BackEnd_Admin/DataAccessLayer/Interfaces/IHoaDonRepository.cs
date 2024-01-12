using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public partial interface IHoaDonRepository
    {
        HoaDonBanModel GetDataByIDBan(int id);
        bool CreateBan(HoaDonBanModel model);
        bool UpdateBan(HoaDonBanModel model);
        bool DeleteBan(HoaDonBanModel model);
        List<HoaDonBanModel> GetAllBan();


        HoaDonNhapModel GetDataByIDNhap(int id);
        bool CreateNhap(HoaDonNhapModel model);
        bool UpdateNhap(HoaDonNhapModel model);
        bool DeleteNhap(HoaDonNhapModel model);
        List<HoaDonNhapModel> GetAllNhap();
    }
}
