using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class TaiKhoanBusiness: ITaiKhoanBusiness
    {
        private ITaiKhoanRepository _res;
        private string secret;
        public TaiKhoanBusiness(ITaiKhoanRepository res, IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
        }

        public TaiKhoanModel Login(string taikhoan, string matkhau)
        {
            var TKL = _res.Login(taikhoan, matkhau);
            if (TKL == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secret.PadRight(16));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, TKL.TenTaiKhoan.ToString()),                     
                    new Claim(ClaimTypes.Role, TKL.LoaiTaiKhoan)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            TKL.token = tokenHandler.WriteToken(token);
            return TKL;
        }      
    }
}
