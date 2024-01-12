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
    public class NhaCungCapBusiness: INhaCungCapBusiness
    {
        private INhaCungCapRepository _res;
        public NhaCungCapBusiness(INhaCungCapRepository res)
        {
            _res = res;
        }
        public NhaCungCapModel GetDataByID(int id)
        {
            return _res.GetDataByID(id);
        }
        public List<NhaCungCapModel> GetAllNhaCungCap()
        {
            return _res.GetAllNhaCungCap();
        }
        public bool Create(NhaCungCapModel model)
        {
            return _res.Create(model);
        }
        public bool Update(NhaCungCapModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(NhaCungCapModel model)
        {
            return _res.Delete(model);
        }
        public List<NhaCungCapModel> SearchNCC(int pageIndex, int pageSize, out long total, string nameNCC)
        {
            return _res.SearchNCC(pageIndex, pageSize, out total, nameNCC);
        }

    }
}
