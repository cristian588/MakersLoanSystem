using Xunit;
using Moq;
using MakersLoanSystem.User.API.Application.Commands.LoginUser;
using MakersLoanSystem.User.API.Core.Interfaces;
using MakersLoanSystem.User.API.Core.Entities;
using MakersLoanSystem.Shared.DTOs;
using System.Threading;
using System.Threading.Tasks;
using BCrypt.Net;
using MakersLoanSystem.User.API.Core.Entities.MakersLoanSystem.User.API.Core.Entities;

public class LoginUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<ITokenService> _tokenServiceMock;
    private readonly LoginUserCommandHandler _handler;

    public LoginUserCommandHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _tokenServiceMock = new Mock<ITokenService>();
        _handler = new LoginUserCommandHandler(_userRepositoryMock.Object, _tokenServiceMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnAuthResponse_WhenCredentialsAreValid()
    {
        var command = new LoginUserCommand { Email = "test@example.com", Password = "Password123" };
        var user = new AppUser { Email = "test@example.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Password123"), Role = new Role { Name = "User" } };

        _userRepositoryMock.Setup(repo => repo.GetByEmailAsync("test@example.com")).ReturnsAsync(user);
        _tokenServiceMock.Setup(service => service.GenerateToken(user)).Returns("FakeJWTToken");

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal("FakeJWTToken", result.Token);
    }

    [Fact]
    public async Task Handle_ShouldReturnNull_WhenPasswordIsInvalid()
    {
        var command = new LoginUserCommand { Email = "test@example.com", Password = "WrongPassword" };
        var user = new AppUser { Email = "test@example.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Password123"), Role = new Role { Name = "User" } };

        _userRepositoryMock.Setup(repo => repo.GetByEmailAsync("test@example.com")).ReturnsAsync(user);

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.Null(result);
    }
}
