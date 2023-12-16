using DataModel;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer
{
    public class NhaCungCapRepository : INhaCungCapRepository
    {
        private IDatabaseHelper _databaseHelper;
        public NhaCungCapRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }
        public NhaCungCapModel GetDataByID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _databaseHelper.ExecuteSProcedureReturnDataTable(out msgError,
                    "sp_nha_cung_cap_get_by_id",
                    "@MaNhaCungCap", id);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return dt.ConvertTo<NhaCungCapModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(NhaCungCapModel model)
        {
            string msgError = "";
            try
            {
                var result = _databaseHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nha_cung_cap_create",
                "@MaNhaCungCap", model.MaNhaCungCap,
                "@TenNhaCungCap", model.TenNhaCungCap,
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
        public bool Update(NhaCungCapModel model)
        {
            string msgError = "";
            try
            {
                var result = _databaseHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nha_cung_cap_update",
                "@MaNhaCungCap", model.MaNhaCungCap,
                "@TenNhaCungCap", model.TenNhaCungCap,
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
        public bool Delete(NhaCungCapModel model)
        {
            string msgError = "";
            try
            {
                var result = _databaseHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nha_cung_cap_delete",
                "@MaNhaCungCap", model.MaNhaCungCap);
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
        public List<NhaCungCapModel> SearchNCC(int pageIndex, int pageSize, out long total, string nameNCC)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _databaseHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_nha_cung_cap_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@TenNhaCungCap", nameNCC
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<NhaCungCapModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
