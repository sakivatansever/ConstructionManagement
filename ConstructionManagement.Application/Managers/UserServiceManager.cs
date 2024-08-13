using ConstructionManagement.Application.Services;
using ConstructionManagement.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagement.Application.Managers
{
    public class UserServiceManager : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;


        public UserServiceManager(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> RegisterAsync(string username, string password)
        {
            var user = new AppUser { UserName = username }; 
            return await _userManager.CreateAsync(user, password); 
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);  
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return GenerateJwtToken(user); 
            }
            throw  new Exception("Hatalı işlem "); 
        }

        public async Task<string> LogoutAsync()
        {
            throw new NotImplementedException();
        }

        private  string GenerateJwtToken(AppUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])); 
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); 

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),  
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token); 
        }


    }
}
