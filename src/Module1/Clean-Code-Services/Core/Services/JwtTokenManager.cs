﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Clean_Code_Services.Core.Services
{
    public interface IJwtTokenManager
    {
        string Authenticate(string userName, string password);
    }
    public class JwtTokenManager(IConfiguration configuration) : IJwtTokenManager
    {
        public string Authenticate(string userName, string password)
        {
            var key = configuration.GetValue<string>("JwtConfig:Key");
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                 {
                 new Claim(ClaimTypes.NameIdentifier, userName)
                 }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(
                                      new SymmetricSecurityKey(keyBytes),
                                      SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
