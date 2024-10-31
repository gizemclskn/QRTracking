using Business.CQRS.Commands;
using DataAccess.Data;
using Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CQRS
{
    public class RegisterExitCommandHandler : IRequestHandler<RegisterExitCommand, bool>
    {
        private readonly AppDbContext _context;

        public RegisterExitCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(RegisterExitCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.Include(e => e.Office)
                                .FirstOrDefaultAsync(e => e.Id == request.EmployeeId);
            if (employee == null) return false;

            // Konum doğrulama
            var office = employee.Office;
            if (request.Location != office.Location)
            {
                
                return false; 
            }

            var record = new AttendanceRecord
            {
                Id = Guid.NewGuid(),
                EmployeeId = employee.Id,
                Timestamp = DateTime.UtcNow,
                ActionType = "Çıkış",
                Location = request.Location
            };

            _context.AttendanceRecords.Add(record);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
