using Xunit;
using Moq;
using MakersLoanSystem.Loan.API.Core.Interfaces;
using MakersLoanSystem.Loan.API.Application.Commands.UpdateLoanStatus;
using System.Threading;
using System.Threading.Tasks;
using System;

public class UpdateLoanStatusCommandHandlerTests
{
    private readonly Mock<ILoanRepository> _loanRepositoryMock;
    private readonly UpdateLoanStatusCommandHandler _handler;

    public UpdateLoanStatusCommandHandlerTests()
    {
        _loanRepositoryMock = new Mock<ILoanRepository>();
        _handler = new UpdateLoanStatusCommandHandler(_loanRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldUpdateLoanStatus_WhenLoanExists()
    {
        var command = new UpdateLoanStatusCommand
        {
            LoanId = Guid.NewGuid(),
            StatusId = 2
        };

        _loanRepositoryMock.Setup(repo => repo.UpdateStatusAsync(command.LoanId, command.StatusId)).Returns(Task.CompletedTask);

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.True(result);
        _loanRepositoryMock.Verify(repo => repo.UpdateStatusAsync(command.LoanId, command.StatusId), Times.Once);
    }
}
