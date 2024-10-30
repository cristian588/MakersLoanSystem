using MakersLoanSystem.Shared.DTOs;
using MakersLoanSystem.User.API.Application.Commands.RegisterUser;
using MakersLoanSystem.User.API.Application.Commands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakersLoanSystem.User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            var command = new RegisterUserCommand { Email = dto.Email, Password = dto.Password, Role = dto.Role };
            var result = await _mediator.Send(command);
            return result ? Ok() : BadRequest();
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login([FromBody] UserLoginDto dto)
        {
            var command = new LoginUserCommand { Email = dto.Email, Password = dto.Password };
            var result = await _mediator.Send(command);
            return result != null ? Ok(result) : Unauthorized();
        }
    }
}
