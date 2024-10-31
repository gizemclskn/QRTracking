using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CQRS.Commands
{
    public class RegisterQrScanCommand : IRequest<bool>
    {
        public Guid EmployeeId { get; set; }
        public string ActionType { get; set; } // Giriş veya Çıkış
    }
}
