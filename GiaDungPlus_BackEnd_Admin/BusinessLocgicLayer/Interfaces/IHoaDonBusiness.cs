using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public partial interface IHoaDonBusiness
    {
        HoaDonBanModel GetDataByIDBan(int id);
        bool CreateBan(HoaDonBanModel model);
        bool UpdateBan(HoaDonBanModel model);
        bool DeleteBan(HoaDonBanModel model);

        HoaDonNhapModel GetDataByIDNhap(int id);
        bool CreateNhap(HoaDonNhapModel model);
        bool UpdateNhap(HoaDonNhapModel model);
        bool DeleteNhap(HoaDonNhapModel model);
    }
}
