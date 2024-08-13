using ConstructionManagement.Application.DTOs;
using ConstructionManagement.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionManagement.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

  


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await _userService.RegisterAsync(registerDto.Username, registerDto.Password);
            if (result.Succeeded)
            {
                return Ok("Kayıt tamamlandı"); 
            }
            return BadRequest(result.Errors); 
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token = await _userService.LoginAsync(loginDto.Username, loginDto.Password);
            if (token != null)
            {
                return Ok(new { Token = token }); 
            }
            return Unauthorized(); 
        }
    }
}
