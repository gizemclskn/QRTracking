using Business.CQRS.Commands;
using DataAccess.Data;
using Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CQRS
{
    public class RegisterQrScanCommandHandler : IRequestHandler<RegisterQrScanCommand, bool>
    {
        private readonly AppDbContext _context;

        public RegisterQrScanCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(RegisterQrScanCommand request, CancellationToken cancellationToken)
        {
            var qrScanEvent = new QrCodeScannedEvent
            {
                EmployeeId = request.EmployeeId,
                ScannedAt = DateTime.UtcNow,
                ActionType = request.ActionType
            };

            await _context.QrCodeScannedEvents.AddAsync(qrScanEvent);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
