using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CQRS.Commands
{
    public class CreateOfficeCommand : IRequest<Guid>
    {
        [Required] 
        public string Name { get; set; }

        [Required] 
        public string Location { get; set; }

        public string Address { get; set; }

        public string QrCode { get; set; }

    }
}
