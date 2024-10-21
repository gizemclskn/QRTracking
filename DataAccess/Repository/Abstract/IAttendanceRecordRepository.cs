using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Abstract
{
    public interface IAttendanceRecordRepository : IRepository<AttendanceRecord>
    {
        Task<IEnumerable<AttendanceRecord>> GetByEmployeeId(Guid employeeId);
    }
}
