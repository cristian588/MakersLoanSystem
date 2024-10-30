using MakersLoanSystem.User.API.Core.Entities;
using MakersLoanSystem.User.API.Core.Interfaces;
using MediatR;
using BCrypt.Net;

namespace MakersLoanSystem.User.API.Application.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var role = await _userRepository.GetRoleByNameAsync(request.Role);
            if (role == null) return false;

            var user = new AppUser
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                PasswordHash = passwordHash,
                RoleId = role.Id
            };

            await _userRepository.AddAsync(user);
            return true;
        }
    }
}
