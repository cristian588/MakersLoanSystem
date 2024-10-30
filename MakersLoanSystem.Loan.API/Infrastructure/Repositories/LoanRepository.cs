using MakersLoanSystem.Loan.API.Core.Interfaces;
using MakersLoanSystem.Loan.API.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace MakersLoanSystem.Loan.API.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LoanDbContext _context;

        public LoanRepository(LoanDbContext context)
        {
            _context = context;
        }

        public async Task<MakersLoanSystem.Loan.API.Core.Entities.Loan> GetByIdAsync(Guid loanId)
        {
            return await _context.Loans.Include(l => l.LoanStatus).FirstOrDefaultAsync(l => l.Id == loanId);
        }

        public async Task<IEnumerable<MakersLoanSystem.Loan.API.Core.Entities.Loan>> GetAllLoansAsync()
        {
            return await _context.Loans.Include(l => l.LoanStatus).ToListAsync();
        }

        public async Task AddAsync(MakersLoanSystem.Loan.API.Core.Entities.Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(Guid loanId, int statusId)
        {
            var loan = await _context.Loans.FindAsync(loanId);
            if (loan != null)
            {
                loan.LoanStatusId = statusId;
                await _context.SaveChangesAsync();
            }
        }
    }
}
