using MediatR;
using MakersLoanSystem.Loan.API.Core.Interfaces;
using MakersLoanSystem.Loan.API.Core.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MakersLoanSystem.Loan.API.Application.Commands.CreateLoan
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, Guid>
    {
        private readonly ILoanRepository _loanRepository;

        public CreateLoanCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<Guid> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = new MakersLoanSystem.Loan.API.Core.Entities.Loan
            {
                Id = Guid.NewGuid(),
                Amount = request.Amount,
                LoanStatusId = 1,
                UserId = request.UserId
            };

            await _loanRepository.AddAsync(loan);
            return loan.Id;
        }
    }
}
