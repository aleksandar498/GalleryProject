using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryProject.Data
{
    public class JwtToken
    {
        private const string SECRETKEY = "mykeyjwtmykeyjwtmykeyjwtmykeyjwtmykeyjwtmykeyjwtmykeyjwtmykeyjwt";
        public static readonly SymmetricSecurityKey SIGNINGKEY = new
            SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRETKEY));

        public static string GenerateJwtToken()
        {
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(SIGNINGKEY, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credentials);
            DateTime expiry = DateTime.UtcNow.AddMinutes(60);
            int ts = (int)(expiry - new DateTime(1970, 1, 1)).TotalSeconds;
            var payload = new JwtPayload
            {
                {"sub","testSubject" },
                {"name","scot" },
                {"email","email.com" },
                {"exp",ts },
                {"iss","https://localhost:44301" },
                {"aud","https://localhost:44301" }
            };
            var securityToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();
            var tokenString = handler.WriteToken(securityToken);
            return tokenString;

        }

    }
}
