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
    public class KhachHangRepository:IKhachHangRepository
    {
        private IDatabaseHelper _databaseHelper;
        public KhachHangRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }
        public KhachHangModel GetDataByID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _databaseHelper.ExecuteSProcedureReturnDataTable(out msgError, 
                    "sp_khach_hang_get_by_id",
                    "@MaKhachHang", id);
                if (!string.IsNullOrEmpty(msgError)) 
                { 
                    throw new Exception(msgError);
                }
                return dt.ConvertTo<KhachHangModel>().FirstOrDefault();
            }
            catch(Exception ex) 
            { 
                throw ex;
            }
        }
        public bool Create(KhachHangModel model)
        {
            string msgError = "";
            try
            {
                var result = _databaseHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_khach_hang_create",
                "@MaKhachHang", model.MaKhachHang,
                "@TenKhachHang", model.TenKhachHang,
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
        public bool Update(KhachHangModel model)
        {
            string msgError = "";
            try
            {
                var result = _databaseHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_khach_hang_update",
                "@MaKhachHang", model.MaKhachHang,
                "@TenKhachHang", model.TenKhachHang,
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
        public bool Delete(KhachHangModel model)
        {
            string msgError = "";
            try
            {
                var result = _databaseHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_khach_hang_delete",
                "@MaKhachHang", model.MaKhachHang);
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
        public List<KhachHangModel> SearchKhachHang(int pageIndex, int pageSize, out long total, string nameKH, string diaChi)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _databaseHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_khach_hang_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@TenKhachHang", nameKH,
                    "@DiaChi", diaChi
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<KhachHangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<KhachHangModel> GetAllKhachHang()
        {
            string msgError = "";
            try
            {
                var dt = _databaseHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_khachhang");

                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                return dt.ConvertTo<KhachHangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
