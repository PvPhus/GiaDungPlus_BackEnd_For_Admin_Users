using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class NhanVienRepository:INhanVienRepository
    {
        private IDatabaseHelper _databaseHelper;
        public NhanVienRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }
        public NhanVienModel GetDataByID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _databaseHelper.ExecuteSProcedureReturnDataTable(out msgError,
                    "sp_nhan_vien_get_by_id",
                    "@MaNhanVien", id);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return dt.ConvertTo<NhanVienModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NhanVienModel> GetAllNhanVien()
        {
            string msgError = "";
            try
            {
                var dt = _databaseHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_nhanvien");

                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                return dt.ConvertTo<NhanVienModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(NhanVienModel model)
        {
            string msgError = "";
            try
            {
                var result = _databaseHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nhan_vien_create",
                "@MaNhanVien", model.MaNhanVien,
                "@TenNhanVien", model.TenNhanVien,
                "@ChucVu", model.ChucVu,
                "@NgaySinh", model.NgaySinh,
                "@DiaChi", model.DiaChi,
                "@SoDienThoai", model.SoDienThoai);
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
        public bool Update(NhanVienModel model)
        {
            string msgError = "";
            try
            {
                var result = _databaseHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nhan_vien_update",
                "@MaNhanVien", model.MaNhanVien,
                "@TenNhanVien", model.TenNhanVien,
                "@ChucVu", model.ChucVu,
                "@NgaySinh", model.NgaySinh,
                "@DiaChi", model.DiaChi,
                "@SoDienThoai", model.SoDienThoai);
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
        public bool Delete(NhanVienModel model)
        {
            string msgError = "";
            try
            {
                var result = _databaseHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nhan_vien_delete",
                "@MaNhanVien", model.MaNhanVien);
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
        public List<NhanVienModel> SearchNhanVien(int pageIndex, int pageSize, out long total, string nameNV)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _databaseHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_nhan_vien_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@TenNhanVien", nameNV
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<NhanVienModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
