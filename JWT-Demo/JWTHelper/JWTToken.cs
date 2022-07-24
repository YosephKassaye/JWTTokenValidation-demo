using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT_Demo.JWTHelper
{
    public static class JWTToken
    {
        private const string SECRET_KEY = "my-32-character-ultra-secure-and-ultra-long-secret";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new
            SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));

        public static string GenerateJWTToken()
        {
            var credentials = new SigningCredentials
                (SIGNING_KEY, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(credentials);
            DateTime Expiry = DateTime.UtcNow.AddMinutes(1);
            int ts = (int)(Expiry - new DateTime(1970, 1, 1)).TotalSeconds;
            var payload = new JwtPayload
            {
                {"sub", "testSubject" },
                {"Name","Yoseph" },
                {"email","yadugna@gmail.com" },
                {"exp", ts },
                {"iss","https://localhost:44362" },
                {"aud","https://localhost:44362" }

            };
            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();
            var tokenString = handler.WriteToken(secToken);
            Console.WriteLine(tokenString);
            Console.WriteLine("Consumed");
            return tokenString;
        }
    }
}
