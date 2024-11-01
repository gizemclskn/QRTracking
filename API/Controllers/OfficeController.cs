using Business.CQRS.Commands;
using DataAccess.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly AppDbContext _context;

        public OfficeController(IMediator mediator, AppDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOffice(CreateOfficeCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

 
            var officeId = await _mediator.Send(command);

       
            var qrCodeCommand = new CreateQrCodeForOfficeCommand(officeId);
            await _mediator.Send(qrCodeCommand);

            var office = await _context.Offices.FindAsync(officeId);
            if (office == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetOfficeById), new { id = officeId }, office);
        }
 [HttpGet("{id}")]
        public async Task<IActionResult> GetOfficeById(Guid id)
        {
            var office = await _context.Offices.FindAsync(id);
            if (office == null)
            {
                return NotFound();
            }

            return Ok(office); 
        }
       
    }
}
