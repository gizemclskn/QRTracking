using Business.CQRS.Commands;
using DataAccess.Data;
using Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Business.CQRS
{
    public class CreateOfficeCommandHandler : IRequestHandler<CreateOfficeCommand, Guid>
    {
        private readonly AppDbContext _context;

        public CreateOfficeCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
        {
            var office = new Office
            {
                Name = request.Name,
                Location = request.Location,
                Address = request.Address,
                QrCode = request.QrCode
            };

            await _context.Offices.AddAsync(office, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return office.Id; 
        }
    }
}
