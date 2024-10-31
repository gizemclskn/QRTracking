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
    public class RegisterEntryCommandHandler : IRequestHandler<RegisterEntryCommand, bool>
    {
        private readonly InMemoryDbContext _context;

        public RegisterEntryCommandHandler(InMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(RegisterEntryCommand request, CancellationToken cancellationToken)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == request.EmployeeId);
            if (employee == null) return false;

            var record = new AttendanceRecord
            {
                Id = Guid.NewGuid(),
                EmployeeId = employee.Id,
                Timestamp = DateTime.UtcNow,
                ActionType = "Giriş",
                Location = request.Location
            };

            _context.AttendanceRecords.Add(record);
            return true; // No database save needed
        }
    }
}
