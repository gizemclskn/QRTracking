using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class AttendanceRecordDTO
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime? EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public double LocationLat { get; set; }
        public double LocationLong { get; set; }
        public bool IsEntry { get; set; }
    }
}
