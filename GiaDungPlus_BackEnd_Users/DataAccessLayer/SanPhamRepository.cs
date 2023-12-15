using Azure.Messaging;
using DataAccessLayer.Interfaces;
using DataModel;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class SanPhamRepository : ISanPhamRepository
    {
        private IDatabaseHelper _dbHelper;     
        public SanPhamRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<DoGiaDungModel> SearchProducts(int pageIndex, int pageSize, out long total, string ten_SanPham)
        {
            string msgError = "Sản phẩm không tồn tại";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sanpham_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ten_sanpham", ten_SanPham                  
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<DoGiaDungModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
