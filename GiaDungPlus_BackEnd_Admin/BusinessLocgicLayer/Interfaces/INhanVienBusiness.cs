using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public partial interface INhanVienBusiness
    {
        NhanVienModel GetDataByID(int id);
        bool Create(NhanVienModel model);
        bool Update(NhanVienModel model);
        bool Delete(NhanVienModel model);
        public List<NhanVienModel> SearchNhanVien(int pageIndex, int pageSize, out long total, string nameNV);
    }
}
