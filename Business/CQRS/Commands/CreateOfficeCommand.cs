using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CQRS.Commands
{
    public class CreateOfficeCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Address { get; set; }

    }
}
