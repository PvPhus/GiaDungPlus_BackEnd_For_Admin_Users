using DataModel;

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
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sanpham_get_by_id",
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
    }
}
