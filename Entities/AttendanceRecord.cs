using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AttendanceRecord
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime Timestamp { get; set; }
        public string ActionType { get; set; } // Giriş veya Çıkış
        public string Location { get; set; } //  konum bilgisi
    }
}
