using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class InMemoryDbContext
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Office> Offices { get; set; } = new List<Office>();
        public List<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();

        public InMemoryDbContext()
        {
            // Seed some initial data
            var office1 = new Office { Id = Guid.NewGuid(), Name = "Main Office", Address = "123 Main St", Latitude = 40.7128, Longitude = -74.0060 };
            var office2 = new Office { Id = Guid.NewGuid(), Name = "Branch Office", Address = "456 Branch Ave", Latitude = 34.0522, Longitude = -118.2437 };
            Offices.AddRange(new[] { office1, office2 });

            var employee1 = new Employee { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe", OfficeId = office1.Id, Username = "johndoe", Password = "hashedpassword" };
            var employee2 = new Employee { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", OfficeId = office2.Id, Username = "janesmith", Password = "hashedpassword" };
            Employees.AddRange(new[] { employee1, employee2 });
        }
    }
}