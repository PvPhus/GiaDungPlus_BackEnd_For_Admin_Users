using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Api.GiaDungPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoGiaDungController : ControllerBase
    { 
        private IDoGiaDungBusiness _sanPhamBusiness;
        private string _path;
        public DoGiaDungController(IDoGiaDungBusiness sanPhamBusiness)
        {
            _sanPhamBusiness = sanPhamBusiness;
        }
        [Route("get-by-id/{id}:")]
        [HttpGet]
        public DoGiaDungModel GetDatabyID(int id)
        {
            return _sanPhamBusiness.GetChiTietDoGiadung(id);
        }
        [Route("create-DoGiaDung")]
        [HttpPost]
        public DoGiaDungModel CreateItem([FromBody] DoGiaDungModel model)
        {
            _sanPhamBusiness.Create(model);
            return model;
        }
        [Route("update-DoGiaDung")]
        [HttpPut]
        public DoGiaDungModel UpdateItem([FromBody] DoGiaDungModel model)
        {
            _sanPhamBusiness.Update(model);
            return model;
        }
        [Route("delete-DoGiaDung")]
        [HttpDelete]
        public DoGiaDungModel DeleteItem([FromBody] DoGiaDungModel model)
        {
            _sanPhamBusiness.Delete(model);
            return model;
        }
        [NonAction]
        public string CreatePathFile(string RelativePathFileName)
        {
            try
            {

                string serverRootPathFolder = @"D:\BaiTapLonWeb-FontEnd-BackEnd";
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                return fullPathFile;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("upload")]
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    string filePath = $"images/{file.FileName}";
                    var fullPath = CreatePathFile(filePath);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return Ok(new { filePath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Không tìm thấy");
            }
        }
        [Route("get_all_products")]
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _sanPhamBusiness.GetAllProducts();
            return Ok(products);
        }
        [Route("get-by-id-loai/{id}:")]
        [HttpGet]
        public LoaiDoGiaDung GetDatabyIDLoai(int id)
        {
            return _sanPhamBusiness.GetChiTietLoaiDoGiadung(id);
        }
        [Route("create-LoaiDoGiaDung")]
        [HttpPost]
        public LoaiDoGiaDung CreateL([FromBody] LoaiDoGiaDung model)
        {
            _sanPhamBusiness.CreateL(model);
            return model;
        }
        [Route("update-LoaiDoGiaDung")]
        [HttpPut]
        public LoaiDoGiaDung UpdateL([FromBody] LoaiDoGiaDung model)
        {
            _sanPhamBusiness.UpdateL(model);
            return model;
        }
        [Route("delete-LoaiDoGiaDung")]
        [HttpDelete]
        public LoaiDoGiaDung DeleteL([FromBody] LoaiDoGiaDung model)
        {
            _sanPhamBusiness.DeleteL(model);
            return model;
        }
        [Route("get_all_category")]
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            var catetory = _sanPhamBusiness.GetAllCategory();
            return Ok(catetory);
        }
    }
}
