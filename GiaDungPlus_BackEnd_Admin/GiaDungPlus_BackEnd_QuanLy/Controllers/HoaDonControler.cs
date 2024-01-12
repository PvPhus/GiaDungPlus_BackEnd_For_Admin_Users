using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.GiaDungPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private IHoaDonBusiness _hoaDonBusiness;
        public HoaDonController(IHoaDonBusiness hoaDonBusiness)
        {
            _hoaDonBusiness = hoaDonBusiness;
        }
        [Route("hoadonban-get-by-id/{id}:")]
        [HttpGet]
        public HoaDonBanModel GetDataByIDBan(int id)
        {
            return _hoaDonBusiness.GetDataByIDBan(id);
        }
        [Route("get_all_HoaDonBan")]
        [HttpGet]
        public IActionResult GetAllBan()
        {
            var hoadonbans = _hoaDonBusiness.GetAllBan();
            return Ok(hoadonbans);
        }
        [Route("create-HoaDonBan")]
        [HttpPost]
        public HoaDonBanModel CreateItemBan([FromBody] HoaDonBanModel model)
        {
            _hoaDonBusiness.CreateBan(model);
            return model;
        }
        [Route("update-HoaDonBan")]
        [HttpPut]
        public HoaDonBanModel UpdateItemBan([FromBody] HoaDonBanModel model)
        {
            _hoaDonBusiness.UpdateBan(model);
            return model;
        }
        [Route("delete-HoaDonBan/{maHoaDonBan}")]
        [HttpDelete]
        public HoaDonBanModel DeleteItemBan(int maHoaDonBan)
        {
            HoaDonBanModel modelToDelete = _hoaDonBusiness.GetDataByIDBan(maHoaDonBan);

            if (modelToDelete != null)
            {
                _hoaDonBusiness.DeleteBan(modelToDelete);
            }

            return modelToDelete;
        }

        [Route("hoadonnhap-get-by-id/{id}:")]
        [HttpGet]
        public HoaDonNhapModel GetDataByIDNhap(int id)
        {
            return _hoaDonBusiness.GetDataByIDNhap(id);
        }
        [Route("get_all_HoaDonNhap")]
        [HttpGet]
        public IActionResult GetAllNhap()
        {
            var hoadonnhaps = _hoaDonBusiness.GetAllNhap();
            return Ok(hoadonnhaps);
        }
        [Route("create-HoaDonNhap")]
        [HttpPost]
        public HoaDonNhapModel CreateItemNhap([FromBody] HoaDonNhapModel model)
        {
            _hoaDonBusiness.CreateNhap(model);
            return model;
        }
        [Route("update-HoaDonNhap")]
        [HttpPut]
        public HoaDonNhapModel UpdateItemNhap([FromBody] HoaDonNhapModel model)
        {
            _hoaDonBusiness.UpdateNhap(model);
            return model;
        }
        [Route("delete-HoaDonNhap/{maHoaDonNhap}")]
        [HttpDelete]
        public HoaDonNhapModel DeleteItemNhap(int maHoaDonNhap)
        {
            HoaDonNhapModel modelToDelete = _hoaDonBusiness.GetDataByIDNhap(maHoaDonNhap);

            if (modelToDelete != null)
            {
                _hoaDonBusiness.DeleteNhap(modelToDelete);
            }

            return modelToDelete;
        }
    }
}
