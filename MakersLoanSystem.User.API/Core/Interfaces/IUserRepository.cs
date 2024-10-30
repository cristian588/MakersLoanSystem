using MakersLoanSystem.User.API.Core.Entities;
using MakersLoanSystem.User.API.Core.Entities.MakersLoanSystem.User.API.Core.Entities;

namespace MakersLoanSystem.User.API.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser> GetByEmailAsync(string email);
        Task AddAsync(AppUser user);
        Task<Role> GetRoleByNameAsync(string roleName);
    }
}
