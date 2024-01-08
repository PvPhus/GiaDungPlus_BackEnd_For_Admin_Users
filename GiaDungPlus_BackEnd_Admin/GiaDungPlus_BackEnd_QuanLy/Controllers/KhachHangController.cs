using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Api.GiaDungPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController: ControllerBase
    {
        private IKhachHangBusiness _khachHangBusiness;
        public KhachHangController(IKhachHangBusiness khachHangBusiness)
        {
            _khachHangBusiness = khachHangBusiness;
        }
        [Route("get-by-id/{id}:")]
        [HttpGet]
        public KhachHangModel GetDataByID(int id)
        {
            return _khachHangBusiness.GetDataByID(id);
        }
        [Route("create-KhachHang")]
        [HttpPost]
        public KhachHangModel CreateItem([FromBody] KhachHangModel model)
        {
            _khachHangBusiness.Create(model);
            return model;
        }
        [Route("update-KhachHang")]
        [HttpPut]
        public KhachHangModel UpdateItem([FromBody] KhachHangModel model)
        {
            _khachHangBusiness.Update(model);
            return model;
        }
        [Route("delete-KhachHang/{maKhachHang}")]
        [HttpDelete]
        public KhachHangModel DeleteItem(int maKhachHang)
        {
            KhachHangModel modelToDelete = _khachHangBusiness.GetDataByID(maKhachHang);

            if (modelToDelete != null)
            {
                _khachHangBusiness.Delete(modelToDelete);
            }
            return modelToDelete;
        }
        //[Route("delete-KhachHang")]
        //[HttpDelete]
        //public KhachHangModel DeleteItem([FromBody] KhachHangModel model)
        //{
        //    _khachHangBusiness.Delete(model);
        //    return model;
        //}
        [Route("search-KhachHang")]
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
                string nameKH = "";
                if (formData.Keys.Contains("ten_khachhang") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_khachhang"]))) { nameKH = Convert.ToString(formData["ten_khachhang"]); }
                string diaChi = "";
                if (formData.Keys.Contains("dia_chi") && !string.IsNullOrEmpty(Convert.ToString(formData["dia_chi"]))) { diaChi = Convert.ToString(formData["dia_chi"]); }               
                long total = 0;
                var data = _khachHangBusiness.SearchKhachHang(page, pageSize, out total, nameKH, diaChi);

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
        [Route("get_all_KhachHang")]
        [HttpGet]
        public IActionResult GetAllKhachHang()
        {
            var khachhang = _khachHangBusiness.GetAllKhachHang();
            return Ok(khachhang);
        }
    }
}
