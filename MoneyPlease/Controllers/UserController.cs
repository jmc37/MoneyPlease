using Microsoft.AspNetCore.Mvc;
using MoneyPlease.Dtos;
using MoneyPlease.Services;

namespace MoneyPlease.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly  IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserDto dto)
        {
            var result = await _userService.CreateUserAsync(dto);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {

            var result = await _userService.LoginAsync(dto);

            if(!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            return Ok();
        }
    }
}
