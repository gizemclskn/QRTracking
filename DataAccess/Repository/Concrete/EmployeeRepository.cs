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
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Employee> GetEmployeeWithAttendanceRecords(Guid id)
        {
            return await _context.Employees
                .Include(e => e.AttendanceRecords)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
