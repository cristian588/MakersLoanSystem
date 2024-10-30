using MakersLoanSystem.Loan.API.Core.Entities;

using Microsoft.EntityFrameworkCore;

namespace MakersLoanSystem.Loan.API.Infrastructure.Data
{
    public class LoanDbContext : DbContext
    {
        public LoanDbContext(DbContextOptions<LoanDbContext> options) : base(options) { }
        public DbSet<MakersLoanSystem.Loan.API.Core.Entities.Loan> Loans { get; set; }
        public DbSet<LoanStatus> LoanStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanStatus>().HasData(
                new LoanStatus { Id = 1, StatusName = "Pending" },
                new LoanStatus { Id = 2, StatusName = "Approved" },
                new LoanStatus { Id = 3, StatusName = "Rejected" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
