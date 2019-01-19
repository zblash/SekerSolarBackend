using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Helpers.Abstract;

namespace WebAPI.Helpers.Concrete
{
    public class JwtTokenGenerater:IJwtTokenGenerater
    {
        private JwtSecurityTokenHandler _tokenHandler;
        private SecurityToken _token;

        public JwtTokenGenerater()
        {
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public IJwtTokenGenerater Generate(Claim[] claims, byte[] secretKey,int ExpireTime)
        {
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "SomeApp",
                Issuer = "SomeAppwithJWT",
                Subject = new ClaimsIdentity(claims),

                Expires = DateTime.UtcNow.AddDays(ExpireTime),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };
            _token = _tokenHandler.CreateToken(tokenDescriptor);
            return this;
        }

        public string WriteToken()
        {
            return _tokenHandler.WriteToken(_token);
        }
    }
}
