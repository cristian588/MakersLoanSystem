using Xunit;
using Moq;
using MakersLoanSystem.User.API.Application.Commands.RegisterUser;
using MakersLoanSystem.User.API.Core.Interfaces;
using MakersLoanSystem.User.API.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using MakersLoanSystem.User.API.Core.Entities.MakersLoanSystem.User.API.Core.Entities;

public class RegisterUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly RegisterUserCommandHandler _handler;

    public RegisterUserCommandHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _handler = new RegisterUserCommandHandler(_userRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldRegisterUser_WhenRoleExists()
    {
        var command = new RegisterUserCommand { Email = "test@example.com", Password = "Password123", Role = "User" };
        var role = new Role { Id = 1, Name = "User" };

        _userRepositoryMock.Setup(repo => repo.GetRoleByNameAsync("User")).ReturnsAsync(role);

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.True(result);
        _userRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<AppUser>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldReturnFalse_WhenRoleDoesNotExist()
    {
        var command = new RegisterUserCommand { Email = "test@example.com", Password = "Password123", Role = "InvalidRole" };
        _userRepositoryMock.Setup(repo => repo.GetRoleByNameAsync("InvalidRole")).ReturnsAsync((Role)null);

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.False(result);
        _userRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<AppUser>()), Times.Never);
    }
}
