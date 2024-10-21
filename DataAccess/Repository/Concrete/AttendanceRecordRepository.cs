using DataAccess.Data;
using DataAccess.Repository.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Concrete
{
    public class AttendanceRecordRepository : Repository<AttendanceRecord>, IAttendanceRecordRepository
    {
        public AttendanceRecordRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<AttendanceRecord>> GetByEmployeeId(Guid employeeId)
        {
            return await _context.AttendanceRecords
                .Where(a => a.EmployeeId == employeeId)
                .ToListAsync();
        }
    }
}
