namespace MakersLoanSystem.Loan.API.Core.Entities
{
    public class Loan
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public Guid UserId { get; set; }
        public int LoanStatusId { get; set; }
        public LoanStatus LoanStatus { get; set; }
    }
}
