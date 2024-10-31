using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid OfficeId { get; set; }
        public Office Office { get; set; }
        public string Location { get; set; }

    }
}
