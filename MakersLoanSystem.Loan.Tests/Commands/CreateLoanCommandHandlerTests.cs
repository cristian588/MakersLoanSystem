using Xunit;
using Moq;
using MakersLoanSystem.Loan.API.Core.Interfaces;
using MakersLoanSystem.Loan.API.Application.Commands.CreateLoan;
using MakersLoanSystem.Loan.API.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Timers;

public class CreateLoanCommandHandlerTests
{
    private readonly Mock<ILoanRepository> _loanRepositoryMock;
    private readonly CreateLoanCommandHandler _handler;

    public CreateLoanCommandHandlerTests()
    {
        _loanRepositoryMock = new Mock<ILoanRepository>();
        _handler = new CreateLoanCommandHandler(_loanRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldAddLoan_WhenCommandIsValid()
    {
        var command = new CreateLoanCommand
        {
            Amount = 1000.00m,
            UserId = Guid.NewGuid()
        };

        _loanRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Loan>())).Returns(Task.CompletedTask);

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.NotEqual(Guid.Empty, result);
        _loanRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Loan>()), Times.Once);
    }
}
