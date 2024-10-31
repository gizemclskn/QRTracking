using Business.CQRS.Commands;
using DataAccess.Data;
using Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Business.CQRS
{
    public class RegisterEntryCommandHandler : IRequestHandler<RegisterEntryCommand, bool>
    {
        private readonly AppDbContext _context;

        public RegisterEntryCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(RegisterEntryCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == request.EmployeeId, cancellationToken);
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
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
