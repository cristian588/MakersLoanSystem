using MakersLoanSystem.Loan.API.Core.Interfaces;

using MediatR;

namespace MakersLoanSystem.Loan.API.Application.Commands.UpdateLoanStatus
{
    public class UpdateLoanStatusCommandHandler : IRequestHandler<UpdateLoanStatusCommand, bool>
    {
        private readonly ILoanRepository _loanRepository;

        public UpdateLoanStatusCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<bool> Handle(UpdateLoanStatusCommand request, CancellationToken cancellationToken)
        {
            await _loanRepository.UpdateStatusAsync(request.LoanId, request.StatusId);
            return true;
        }
    }
}
