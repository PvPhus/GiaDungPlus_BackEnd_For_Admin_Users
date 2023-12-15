using BusinessLogicLayer.Interfaces;
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
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                if (!formData.Keys.Contains("page") || !formData.Keys.Contains("pageSize"))
                {
                    return BadRequest("Missing 'page' or 'pageSize' in formData");
                }

                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten_sanpham = formData.ContainsKey("ten_sanpham") ? Convert.ToString(formData["ten_sanpham"]) : "";

                long total = 0;
                var data = _sanPhamBusiness.SearchProducts(page, pageSize, out total, ten_sanpham);

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
