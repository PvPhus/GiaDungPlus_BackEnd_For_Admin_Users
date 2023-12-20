using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IDoGiaDungBusiness
    {
        DoGiaDungModel GetChiTietDoGiadung(int id);
        bool Create(DoGiaDungModel model);
        bool Update(DoGiaDungModel model);
        bool Delete(DoGiaDungModel model);
        List<DoGiaDungModel> GetAllProducts();
        bool CreateL(LoaiDoGiaDung model);
        bool UpdateL(LoaiDoGiaDung model);
        bool DeleteL(LoaiDoGiaDung model);
        List<LoaiDoGiaDung> GetAllCategory();
    }
}
