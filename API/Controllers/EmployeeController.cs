using Business.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register-entry")]
        [Authorize]
        public async Task<IActionResult> RegisterEntry([FromBody] RegisterEntryCommand command)
        {
            var result = await _mediator.Send(command);
            if (result)
                return Ok("Entry registered successfully.");
            return BadRequest("Failed to register entry.");
        }

        [HttpPost("register-exit")]
        [Authorize]
        public async Task<IActionResult> RegisterExit([FromBody] RegisterExitCommand command)
        {
            var result = await _mediator.Send(command);
            if (result)
                return Ok("Exit registered successfully.");
            return BadRequest("Failed to register exit.");
        }
    }
}
