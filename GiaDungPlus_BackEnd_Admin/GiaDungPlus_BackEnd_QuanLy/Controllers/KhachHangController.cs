using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Api.GiaDungPlus.Controllers
{
    public class KhachHangController: ControllerBase
    {
        private IKhachHangBusiness _khachHangBusiness;
        public KhachHangController(IKhachHangBusiness khachHangBusiness)
        {
            _khachHangBusiness = khachHangBusiness;
        }
        [Route("get-by-id/id:")]
        [HttpGet]
        public KhachHangModel GetDataByID(int id)
        {
            return _khachHangBusiness.GetDataByID(id);
        }
        [Route("create-DoGiaDung")]
        [HttpPost]
        public KhachHangModel CreateItem([FromBody] KhachHangModel model)
        {
            _khachHangBusiness.Create(model);
            return model;
        }
        [Route("update-DoGiaDung")]
        [HttpPost]
        public KhachHangModel UpdateItem([FromBody] KhachHangModel model)
        {
            _khachHangBusiness.Update(model);
            return model;
        }
        [Route("delete-DoGiaDung")]
        [HttpPost]
        public KhachHangModel DeleteItem([FromBody] KhachHangModel model)
        {
            _khachHangBusiness.Delete(model);
            return model;
        }
        [Route("search")]
        [HttpPost]
        public IActionResult SearchKhachHang([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                if (!formData.Keys.Contains("page") || !formData.Keys.Contains("pageSize"))
                {
                    return BadRequest("Missing 'page' or 'pageSize' in formData");
                }

                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string nameKH = formData.ContainsKey("ten_khachhang") ? Convert.ToString(formData["ten_khachhang"]) : "";

                long total = 0;
                var data = _khachHangBusiness.SearchKhachHang(page, pageSize, out total, nameKH);

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
