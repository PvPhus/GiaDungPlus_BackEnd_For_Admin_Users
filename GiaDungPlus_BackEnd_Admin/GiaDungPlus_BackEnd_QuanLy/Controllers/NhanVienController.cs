using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Api.GiaDungPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController:ControllerBase
    {
        private INhanVienBusiness _NhanVienBusiness;
        public NhanVienController(INhanVienBusiness NhanVienBusiness)
        {
            _NhanVienBusiness = NhanVienBusiness;
        }
        [Route("get-by-id/{id}:")]
        [HttpGet]
        public NhanVienModel GetDataByID(int id)
        {
            return _NhanVienBusiness.GetDataByID(id);
        }
        [Route("get_all_NhanVien")]
        [HttpGet]
        public IActionResult GetAllNhanVien()
        {
            var nhanviens = _NhanVienBusiness.GetAllNhanVien();
            return Ok(nhanviens);
        }
        [Route("create-NhanVien")]
        [HttpPost]
        public NhanVienModel CreateItem([FromBody] NhanVienModel model)
        {
            _NhanVienBusiness.Create(model);
            return model;
        }
        [Route("update-NhanVien")]
        [HttpPut]
        public NhanVienModel UpdateItem([FromBody] NhanVienModel model)
        {
            _NhanVienBusiness.Update(model);
            return model;
        }
        [Route("delete-NhanVien")]
        [HttpDelete]
        public NhanVienModel DeleteItem([FromBody] NhanVienModel model)
        {
            _NhanVienBusiness.Delete(model);
            return model;
        }
        [Route("delete-NhanVien/{maNhanVien}")]
        [HttpDelete]
        public NhanVienModel DeleteItem(int maNhanVien)
        {
            NhanVienModel modelToDelete = _NhanVienBusiness.GetDataByID(maNhanVien);

            if (modelToDelete != null)
            {
                _NhanVienBusiness.Delete(modelToDelete);
            }

            return modelToDelete;
        }
        [Route("search-NhanVien")]
        [HttpPost]
        public IActionResult SearchNhanVien([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                if (!formData.Keys.Contains("page") || !formData.Keys.Contains("pageSize"))
                {
                    return BadRequest("Missing 'page' or 'pageSize' in formData");
                }

                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string nameNV = formData.ContainsKey("ten_NhanVien") ? Convert.ToString(formData["ten_NhanVien"]) : "";

                long total = 0;
                var data = _NhanVienBusiness.SearchNhanVien(page, pageSize, out total, nameNV);

                return Ok(new
                {
                    TotalItems = total,
                    Data = data,
                    Page = page,
                    PageSize = pageSize
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
