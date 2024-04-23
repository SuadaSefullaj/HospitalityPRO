using Entities.Models;
using HumanResourceProject.Models;
using Microsoft.AspNetCore.Http;
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

namespace Helpers
{
    public class TokenService
    {
        private readonly IConfiguration _configuration; //it's used to retrieve the token secret key from the configuration, which is then used to generate JWT tokens for authentication purposes.
        private readonly HospitalityPRO_DbContext _dbContext;

        public TokenService(IConfiguration configuration, HospitalityPRO_DbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public string CreateToken(Client client)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("emailaddress", client.Email),
                new Claim("name", client.Name),
                new Claim("role", client.Role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value)); //Retrieves the secret key from the application settings. This key is used to sign the JWT.

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        public static RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {

                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }
        public void SetRefreshToken(HttpContext httpContext, Client client, RefreshToken refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshToken.Expires
            };
            httpContext.Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

            _dbContext.RefreshTokens.Add(refreshToken);
            _dbContext.SaveChanges();
        }
    }
}
