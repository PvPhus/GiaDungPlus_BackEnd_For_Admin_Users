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
        public List<DoGiaDungModel> GetAllProducts()
        {
            return _res.GetAllProducts();
        }
        public bool CreateL(LoaiDoGiaDung model)
        {
            return _res.CreateL(model);
        }
        public bool UpdateL(LoaiDoGiaDung model)
        {
            return _res.UpdateL(model);
        }
        public bool DeleteL(LoaiDoGiaDung model)
        {
            return _res.DeleteL(model);
        }
        public List<LoaiDoGiaDung> GetAllCategory()
        {
            return _res.GetAllCategory();
        }
    }
}