namespace MakersLoanSystem.User.API.Core.Entities
{
    namespace MakersLoanSystem.User.API.Core.Entities
    {
        public class Role
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ICollection<AppUser> Users { get; set; }
        }
    }

}
