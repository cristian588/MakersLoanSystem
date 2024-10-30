namespace MakersLoanSystem.Loan.API.Core.Interfaces
{
    public interface ILoanRepository
    {
        Task<MakersLoanSystem.Loan.API.Core.Entities.Loan> GetByIdAsync(Guid loanId);
        Task<IEnumerable<MakersLoanSystem.Loan.API.Core.Entities.Loan>> GetAllLoansAsync();
        Task AddAsync(MakersLoanSystem.Loan.API.Core.Entities.Loan loan);
        Task UpdateStatusAsync(Guid loanId, int statusId);
    }
}
