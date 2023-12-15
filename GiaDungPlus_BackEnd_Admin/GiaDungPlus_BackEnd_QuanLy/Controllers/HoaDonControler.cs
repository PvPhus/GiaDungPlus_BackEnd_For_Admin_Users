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
        [Route("hoadonban-get-by-id/id:")]
        [HttpGet]
        public HoaDonBanModel GetDataByIDBan(int id)
        {
            return _hoaDonBusiness.GetDataByIDBan(id);
        }
        [Route("create-HoaDonBan")]
        [HttpPost]
        public HoaDonBanModel CreateItemBan([FromBody] HoaDonBanModel model)
        {
            _hoaDonBusiness.CreateBan(model);
            return model;
        }
        [Route("update-HoaDonBan")]
        [HttpPost]
        public HoaDonBanModel UpdateItemBan([FromBody] HoaDonBanModel model)
        {
            _hoaDonBusiness.UpdateBan(model);
            return model;
        }
        [Route("delete-HoaDonBan")]
        [HttpPost]
        public HoaDonBanModel DeleteItemBan([FromBody] HoaDonBanModel model)
        {
            _hoaDonBusiness.DeleteBan(model);
            return model;
        }

        [Route("hoadonnhap-get-by-id/id:")]
        [HttpGet]
        public HoaDonNhapModel GetDataByIDNhap(int id)
        {
            return _hoaDonBusiness.GetDataByIDNhap(id);
        }
        [Route("create-HoaDonBan")]
        [HttpPost]
        public HoaDonNhapModel CreateItemNhap([FromBody] HoaDonNhapModel model)
        {
            _hoaDonBusiness.CreateNhap(model);
            return model;
        }
        [Route("update-HoaDonBan")]
        [HttpPost]
        public HoaDonNhapModel UpdateItemNhap([FromBody] HoaDonNhapModel model)
        {
            _hoaDonBusiness.UpdateNhap(model);
            return model;
        }
        [Route("delete-HoaDonBan")]
        [HttpPost]
        public HoaDonNhapModel DeleteItemNhap([FromBody] HoaDonNhapModel model)
        {
            _hoaDonBusiness.DeleteNhap(model);
            return model;
        }
    }
}
