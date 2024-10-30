using MediatR;

using System;

namespace MakersLoanSystem.Loan.API.Application.Commands.UpdateLoanStatus
{
    public class UpdateLoanStatusCommand : IRequest<bool>
    {
        public Guid LoanId { get; set; }
        public int StatusId { get; set; }
    }
}
