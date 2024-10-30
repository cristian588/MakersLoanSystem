using Xunit;
using MakersLoanSystem.User.API.Core.Entities;
using MakersLoanSystem.User.API.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using MakersLoanSystem.User.API.Core.Entities.MakersLoanSystem.User.API.Core.Entities;
using Moq;

public class TokenServiceTests
{
    private readonly TokenService _tokenService;

    public TokenServiceTests()
    {
        var configurationMock = new Mock<IConfiguration>();
        configurationMock.SetupGet(c => c["Jwt:Key"]).Returns("YourSuperSecureKeyWithAtLeast32Chars1234");
        configurationMock.SetupGet(c => c["Jwt:Issuer"]).Returns("MakersLoanSystem");
        configurationMock.SetupGet(c => c["Jwt:Audience"]).Returns("MakersLoanSystemUsers");

        _tokenService = new TokenService(configurationMock.Object);
    }

    [Fact]
    public void GenerateToken_ShouldReturnToken_WhenUserIsValid()
    {
        var user = new AppUser
        {
            Email = "test@example.com",
            Role = new Role { Name = "User" }
        };

        var token = _tokenService.GenerateToken(user);

        Assert.NotNull(token);
        Assert.IsType<string>(token);
    }
}
