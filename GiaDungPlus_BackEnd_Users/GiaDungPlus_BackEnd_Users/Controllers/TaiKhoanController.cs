using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.GiaDungPlus_BackEnd_Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private ITaiKhoanBusiness _TaiKhoanBusiness;
        public TaiKhoanController(ITaiKhoanBusiness taiKhoanBusiness)
        {
            _TaiKhoanBusiness = taiKhoanBusiness;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var TaiKhoan = _TaiKhoanBusiness.Login(model.Username, model.Password);
            if (TaiKhoan == null)
                return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            return Ok(new { taikhoan = TaiKhoan.TenTaiKhoan, loaitaikhoan = TaiKhoan.LoaiTaiKhoan, token = TaiKhoan.token });
        }
    }
}
