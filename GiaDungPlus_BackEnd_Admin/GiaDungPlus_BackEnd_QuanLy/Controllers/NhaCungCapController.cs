using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Api.GiaDungPlus.Controllers
{
    public class NhaCungCapController:ControllerBase
    {
        private INhaCungCapBusiness _NhaCungCapBusiness;
        public NhaCungCapController(INhaCungCapBusiness NhaCungCapBusiness)
        {
            _NhaCungCapBusiness = NhaCungCapBusiness;
        }
        [Route("get-by-id/id:")]
        [HttpGet]
        public NhaCungCapModel GetDataByID(int id)
        {
            return _NhaCungCapBusiness.GetDataByID(id);
        }
        [Route("create-DoGiaDung")]
        [HttpPost]
        public NhaCungCapModel CreateItem([FromBody] NhaCungCapModel model)
        {
            _NhaCungCapBusiness.Create(model);
            return model;
        }
        [Route("update-DoGiaDung")]
        [HttpPost]
        public NhaCungCapModel UpdateItem([FromBody] NhaCungCapModel model)
        {
            _NhaCungCapBusiness.Update(model);
            return model;
        }
        [Route("delete-DoGiaDung")]
        [HttpPost]
        public NhaCungCapModel DeleteItem([FromBody] NhaCungCapModel model)
        {
            _NhaCungCapBusiness.Delete(model);
            return model;
        }
        [Route("search")]
        [HttpPost]
        public IActionResult SearchNhaCungCap([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                if (!formData.Keys.Contains("page") || !formData.Keys.Contains("pageSize"))
                {
                    return BadRequest("Missing 'page' or 'pageSize' in formData");
                }

                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string nameNCC = formData.ContainsKey("ten_nhacungcap") ? Convert.ToString(formData["ten_nhacungcap"]) : "";

                long total = 0;
                var data = _NhaCungCapBusiness.SearchNCC(page, pageSize, out total, nameNCC);

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
