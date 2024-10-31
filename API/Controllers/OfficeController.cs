using MediatR;
using Microsoft.AspNetCore.Mvc;
using Business.CQRS.Commands;
using Business.CQRS; 
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfficeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOffice([FromBody] CreateOfficeCommand command)
        {
            var result = await _mediator.Send(command);
            if (result)
                return Ok("Office created successfully.");
            return BadRequest("Failed to create office.");
        }

        [HttpPost("{officeId}/generate-qr")]
        public async Task<IActionResult> GenerateQrCode(Guid officeId)
        {
            var result = await _mediator.Send(new CreateQrCodeForOfficeCommand { OfficeId = officeId });
            if (result)
                return Ok("QR Code generated successfully.");
            return BadRequest("Failed to generate QR code.");
        }

        [HttpGet("{officeId}")]
        public async Task<IActionResult> GetOfficeDetails(Guid officeId)
        {
            var result = await _mediator.Send(new GetOfficeDetailsQuery { OfficeId = officeId });
            if (result == null)
                return NotFound("Office not found.");
            return Ok(result);
        }
    }
}
