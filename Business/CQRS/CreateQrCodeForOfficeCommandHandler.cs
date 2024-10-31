using Business.CQRS.Commands;
using DataAccess.Data;
using MediatR;
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
        private readonly InMemoryDbContext _context;

        public CreateQrCodeForOfficeCommandHandler(InMemoryDbContext context)
        {
            _context = context;
        }

        public Task<bool> Handle(CreateQrCodeForOfficeCommand request, CancellationToken cancellationToken)
        {
            var office = _context.Offices.FirstOrDefault(o => o.Id == request.OfficeId);
            if (office == null) return Task.FromResult(false);

            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(office.Id.ToString(), QRCodeGenerator.ECCLevel.Q);
            var qrCode = new Base64QRCode(qrCodeData);
            office.QrCode = qrCode.GetGraphic(20);

            return Task.FromResult(true);
        }
    }
}
