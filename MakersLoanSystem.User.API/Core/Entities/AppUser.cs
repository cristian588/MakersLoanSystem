using MakersLoanSystem.User.API.Core.Entities.MakersLoanSystem.User.API.Core.Entities;

namespace MakersLoanSystem.User.API.Core.Entities
{
    public class AppUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
