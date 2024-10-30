using MediatR;

using System;

namespace MakersLoanSystem.Loan.API.Application.Commands.CreateLoan
{
    public class CreateLoanCommand : IRequest<Guid>
    {
        public decimal Amount { get; set; }
        public Guid UserId { get; set; }
    }
}
