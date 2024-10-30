using MakersLoanSystem.Loan.API.Application.Commands.CreateLoan;
using MakersLoanSystem.Loan.API.Application.Commands.UpdateLoanStatus;
using MakersLoanSystem.Loan.API.Application.Queries.GetAllLoans;

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MakersLoanSystem.Loan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateLoan([FromBody] CreateLoanCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("update-status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateLoanStatus([FromBody] UpdateLoanStatusCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok() : BadRequest();
        }

        [HttpGet("all-loans")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllLoans()
        {
            var query = new GetAllLoansQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
