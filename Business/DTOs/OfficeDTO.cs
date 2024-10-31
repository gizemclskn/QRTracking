using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class OfficeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double LocationLat { get; set; }
        public double LocationLong { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
    }
}
