using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CQRS.Commands
{
    public class CreateQrCodeForOfficeCommand : IRequest<bool>
    {
        public Guid OfficeId { get; set; }
    }


}
