using MakersLoanSystem.User.API.Core.Entities;

namespace MakersLoanSystem.User.API.Core.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(AppUser user);
    }
}
