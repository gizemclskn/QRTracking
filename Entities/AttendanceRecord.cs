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
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
    }
}
