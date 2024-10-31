using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class QrCodeScannedEvent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid EmployeeId { get; set; }
        public DateTime ScannedAt { get; set; }
        public string ActionType { get; set; } // Giriş veya Çıkış
    }
}
