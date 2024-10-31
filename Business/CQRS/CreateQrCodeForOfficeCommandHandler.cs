using Business.CQRS.Commands;
using DataAccess.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.CQRS
{
    public class CreateQrCodeForOfficeCommandHandler : IRequestHandler<CreateQrCodeForOfficeCommand, bool>
    {
        private readonly AppDbContext _context;

        public CreateQrCodeForOfficeCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateQrCodeForOfficeCommand request, CancellationToken cancellationToken)
        {
            var office = await _context.Offices.FirstOrDefaultAsync(o => o.Id == request.OfficeId, cancellationToken);
            if (office == null) return false;

            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(office.Id.ToString(), QRCodeGenerator.ECCLevel.Q);
            var qrCode = new Base64QRCode(qrCodeData);
            office.QrCode = qrCode.GetGraphic(20);

            _context.Offices.Update(office);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
