using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restful_Api1.Dto;
using Restful_Api1.Service;

namespace Restful_Api1.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    namespace Restful_Api1.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class AuthController : ControllerBase
        {
            private readonly IAuthService _authService;

            public AuthController(IAuthService authService)
            {
                _authService = authService;
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register(RegisterDto dto)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var success = await _authService.RegisterAsync(dto);

                if (!success)
                    return BadRequest("User already exists");

                return Ok("User registered successfully");
            }

           
            [HttpPost("login")]
            public async Task<IActionResult> Login(LoginDto dto)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var token = await _authService.LoginAsync(dto);

                if (token == null)
                    return Unauthorized("Invalid username or password");

                return Ok(new
                {
                    token = token
                });
            }
        }
    }


}

