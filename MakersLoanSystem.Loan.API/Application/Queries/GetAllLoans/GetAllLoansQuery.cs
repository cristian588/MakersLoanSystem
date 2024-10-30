using MediatR;

namespace MakersLoanSystem.Loan.API.Application.Queries.GetAllLoans
{
    public class GetAllLoansQuery : IRequest<IEnumerable<MakersLoanSystem.Loan.API.Core.Entities.Loan>> { }
}
