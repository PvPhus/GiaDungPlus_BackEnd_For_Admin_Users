using DataModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class DoGiaDungRepository : IDoGiaDungRepository
    {
        private IDatabaseHelper _dbHelper;
        public DoGiaDungRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public DoGiaDungModel GetChiTietDoGiaDung(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_san_pham_get_by_id",
                     "@MaSanPham", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DoGiaDungModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(DoGiaDungModel model)
        {
            string msgError = "Thêm thất bại!";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_san_pham_create", 
                "@MaSanPham", model.MaSanPham,
                "@TenSanPham", model.TenSanPham,
                "@Gia", model.Gia,
                "@MoTa", model.MoTa,
                "@HinhAnh", model.HinhAnh,
                "@MaLoai", model.MaLoai);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(DoGiaDungModel model)
        {
            string msgError = "Sửa không thành công!";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_san_pham_update",
                "@MaSanPham", model.MaSanPham,
                "@TenSanPham", model.TenSanPham,
                "@Gia", model.Gia,
                "@MoTa", model.MoTa,
                "@HinhAnh", model.HinhAnh,
                "@MaLoai", model.MaLoai);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(DoGiaDungModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_san_pham_delete",
                "@MaSanPham", model.MaSanPham);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DoGiaDungModel> GetAllProducts()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_products");

                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                return dt.ConvertTo<DoGiaDungModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<LoaiDoGiaDung> GetAllCategory()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_category");

                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                return dt.ConvertTo<LoaiDoGiaDung>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CreateL(LoaiDoGiaDung model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_loai_san_pham_create",
                "@MaLoai", model.MaLoai,
                "@TenLoai", model.TenLoai,
                "@SoLuongLoaiTon", model.SoLuongLoaiTon);              
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateL(LoaiDoGiaDung model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_loai_san_pham_update",
                "@MaLoai", model.MaLoai,
                "@TenLoai", model.TenLoai,
                "@SoLuongLoaiTon", model.SoLuongLoaiTon);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteL(LoaiDoGiaDung model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_loai_san_pham_delete",
                "@MaLoai", model.MaLoai);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
