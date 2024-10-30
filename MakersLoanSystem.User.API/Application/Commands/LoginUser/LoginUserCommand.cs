using MediatR;
using MakersLoanSystem.Shared.DTOs;

namespace MakersLoanSystem.User.API.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<AuthResponseDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
