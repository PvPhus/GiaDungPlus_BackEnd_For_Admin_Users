using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.GiaDungPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ISanPhamBusiness _sanPhamBusiness;
        public SanPhamController(ISanPhamBusiness sanPhamBusiness)
        {
            _sanPhamBusiness = sanPhamBusiness;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public SanPhamModel GetDatabyID(int id)
        {
            return _sanPhamBusiness.GetChiTietSanPham(id);
        }
        [Route("create-san-pham")]
        [HttpPost]
        public SanPhamModel CreateItem([FromBody] SanPhamModel model)
        {
            _sanPhamBusiness.Create(model);
            return model;
        }
        [Route("update-san-pham")]
        [HttpPost]
        public SanPhamModel UpdateItem([FromBody] SanPhamModel model)
        {
            _sanPhamBusiness.Create(model);
            return model;
        }
        [Route("delete-san-pham")]
        [HttpPost]
        public SanPhamModel DeleteItem([FromBody] SanPhamModel model)
        {
            _sanPhamBusiness.Create(model);
            return model;
        }
    }
}
