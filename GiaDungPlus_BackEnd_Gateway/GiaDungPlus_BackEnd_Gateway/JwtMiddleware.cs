using GiaDungPlus_BackEnd_Gateway.Helpers;
using GiaDungPlus_BackEnd_Gateway.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Ocelot.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace GiaDungPlus_BackEnd_Gateway
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        private GiaDungPlusAfterContext db = null;
        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _next = next;
            _appSettings = appSettings.Value;
            db = new GiaDungPlusAfterContext(configuration);
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            context.Response.Headers.Add("Access-Control-Expose-Headers", "*");
            if (!context.Request.Path.Equals("/api/token", StringComparison.Ordinal))
            {
                return _next(context);
            }
            if (context.Request.Method.Equals("POST") && context.Request.HasFormContentType)
            {
                return GenerateToken(context);
            }
            context.Response.StatusCode = 400;
            return context.Response.WriteAsync("Bad request.");
        }

        public async Task GenerateToken(HttpContext context)
        {
            var Taikhoan = context.Request.Form["Taikhoan"].ToString();
            var Matkhau = context.Request.Form["Matkhau"].ToString();
            var query = from n in db.KhachHang
                        join t in db.TaiKhoan on n.MaKhachHang equals t.MaKhachHang
                        select new
                        {
                            MaKhachHang = n.MaKhachHang,
                            TenKhachHang = n.TenKhachHang, 
                            TenTaiKhoan = t.TenTaiKhoan,
                            MatKhau = t.MatKhau,                                                           
                            LoaiTaiKhoan = t.LoaiTaiKhoan
                        };

            var user = query.SingleOrDefault(x => x.TenKhachHang == Taikhoan && x.MatKhau == Matkhau);
            //return null if user not found
            if (user == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var result = JsonConvert.SerializeObject(new { code = (int)HttpStatusCode.BadRequest, error = "Tài khoản hoặc mật khẩu không đúng" });
                await context.Response.WriteAsync(result);
                return;
            }

            //authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.TenKhachHang.ToString()),
                    new Claim(ClaimTypes.Role, user.LoaiTaiKhoan),
                    new Claim(ClaimTypes.DenyOnlyWindowsDeviceGroup, user.MatKhau)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tmp = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(tmp);
            var response = new { MaNguoiDung = user.MaNguoiDung, HoTen = user.HoTen, TaiKhoan = user.TaiKhoan, Token = token };
            var serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, serializerSettings));
            return;
        }
    }
}
