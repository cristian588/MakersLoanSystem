using Xunit;
using Moq;
using MakersLoanSystem.Loan.API.Core.Interfaces;
using MakersLoanSystem.Loan.API.Application.Queries.GetAllLoans;
using MakersLoanSystem.Loan.API.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

public class GetAllLoansQueryHandlerTests
{
    private readonly Mock<ILoanRepository> _loanRepositoryMock;
    private readonly GetAllLoansQueryHandler _handler;

    public GetAllLoansQueryHandlerTests()
    {
        _loanRepositoryMock = new Mock<ILoanRepository>();
        _handler = new GetAllLoansQueryHandler(_loanRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnAllLoans_WhenLoansExist()
    {
        var loans = new List<Loan>
        {
            new Loan { Id = Guid.NewGuid(), Amount = 5000, LoanStatusId = 1 },
            new Loan { Id = Guid.NewGuid(), Amount = 1500, LoanStatusId = 2 }
        };

        _loanRepositoryMock.Setup(repo => repo.GetAllLoansAsync()).ReturnsAsync(loans);

        var result = await _handler.Handle(new GetAllLoansQuery(), CancellationToken.None);

        Assert.Equal(loans.Count, result.Count());
        _loanRepositoryMock.Verify(repo => repo.GetAllLoansAsync(), Times.Once);
    }
}
