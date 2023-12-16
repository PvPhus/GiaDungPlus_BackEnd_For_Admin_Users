using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;
using System.Reflection;

namespace BusinessLogicLayer
{
    public class DoGiaDungBusiness: IDoGiaDungBusiness
    {
        private IDoGiaDungRepository _res;
        public DoGiaDungBusiness(IDoGiaDungRepository res)
        {
            _res = res;
        }
        public DoGiaDungModel GetChiTietDoGiadung(int id)
        {
            return _res.GetChiTietDoGiaDung(id);
        }
        public bool Create(DoGiaDungModel model)
        {
            return _res.Create(model);
        }
        public bool Update(DoGiaDungModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(DoGiaDungModel model)
        {
            return _res.Delete(model);
        }

    }
}