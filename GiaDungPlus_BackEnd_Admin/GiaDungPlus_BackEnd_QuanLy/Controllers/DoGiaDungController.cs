﻿using BusinessLogicLayer;
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
        public DoGiaDungController(IDoGiaDungBusiness sanPhamBusiness)
        {
            _sanPhamBusiness = sanPhamBusiness;
        }
        [Route("get-by-id/id:")]
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
        [HttpPost]
        public DoGiaDungModel UpdateItem([FromBody] DoGiaDungModel model)
        {
            _sanPhamBusiness.Update(model);
            return model;
        }
        [Route("delete-DoGiaDung")]
        [HttpPost]
        public DoGiaDungModel DeleteItem([FromBody] DoGiaDungModel model)
        {
            _sanPhamBusiness.Delete(model);
            return model;
        }
    }
}