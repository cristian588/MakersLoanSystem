using MakersLoanSystem.Loan.API.Core.Interfaces;

using MediatR;

namespace MakersLoanSystem.Loan.API.Application.Queries.GetAllLoans
{
    public class GetAllLoansQueryHandler : IRequestHandler<GetAllLoansQuery, IEnumerable<MakersLoanSystem.Loan.API.Core.Entities.Loan>>
    {
        private readonly ILoanRepository _loanRepository;

        public GetAllLoansQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<IEnumerable<MakersLoanSystem.Loan.API.Core.Entities.Loan>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            return await _loanRepository.GetAllLoansAsync();
        }
    }
}
