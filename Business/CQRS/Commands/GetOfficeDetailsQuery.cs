using Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CQRS.Commands
{
    public class GetOfficeDetailsQuery : IRequest<Office>
    {
        public Guid OfficeId { get; set; }
    }
}
