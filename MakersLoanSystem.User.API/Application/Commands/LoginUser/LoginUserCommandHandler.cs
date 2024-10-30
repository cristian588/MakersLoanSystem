using MakersLoanSystem.User.API.Core.Interfaces;
using MakersLoanSystem.Shared.DTOs;
using MediatR;
using BCrypt.Net;

namespace MakersLoanSystem.User.API.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginUserCommandHandler(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<AuthResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null) return null;

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash)) return null;

            var token = _tokenService.GenerateToken(user);
            return new AuthResponseDto { Token = token, Role = user.Role.Name };
        }
    }
}
