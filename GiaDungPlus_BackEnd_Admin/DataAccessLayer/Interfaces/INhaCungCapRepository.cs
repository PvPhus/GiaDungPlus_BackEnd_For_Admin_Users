using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public partial interface INhaCungCapRepository
    {
        NhaCungCapModel GetDataByID(int id);
        bool Create(NhaCungCapModel model);
        bool Update(NhaCungCapModel model);
        bool Delete(NhaCungCapModel model);
        public List<NhaCungCapModel> SearchNCC(int pageIndex, int pageSize, out long total, string nameNCC);
        List<NhaCungCapModel> GetAllNhaCungCap();
    }
}
