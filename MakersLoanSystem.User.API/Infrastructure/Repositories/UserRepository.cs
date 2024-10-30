using MakersLoanSystem.User.API.Core.Entities;
using MakersLoanSystem.User.API.Core.Entities.MakersLoanSystem.User.API.Core.Entities;
using MakersLoanSystem.User.API.Core.Interfaces;
using MakersLoanSystem.User.API.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace MakersLoanSystem.User.API.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetByEmailAsync(string email)
        {
            return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(AppUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        }
    }
}
