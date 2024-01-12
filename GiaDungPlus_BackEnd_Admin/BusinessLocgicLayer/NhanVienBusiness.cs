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
    public class NhanVienBusiness:INhanVienBusiness
    {
        private INhanVienRepository _res;
        public NhanVienBusiness(INhanVienRepository res)
        {
            _res = res;
        }
        public NhanVienModel GetDataByID(int id)
        {
            return _res.GetDataByID(id);
        }
        public List<NhanVienModel> GetAllNhanVien()
        {
            return _res.GetAllNhanVien();
        }
        public bool Create(NhanVienModel model)
        {
            return _res.Create(model);
        }
        public bool Update(NhanVienModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(NhanVienModel model)
        {
            return _res.Delete(model);
        }
        public List<NhanVienModel> SearchNhanVien(int pageIndex, int pageSize, out long total, string nameNV)
        {
            return _res.SearchNhanVien(pageIndex, pageSize, out total, nameNV);
        }
    }
}
