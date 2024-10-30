using MediatR;

namespace MakersLoanSystem.User.API.Application.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
