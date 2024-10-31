using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Office
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string QrCode { get; set; } // QR Kod URL veya Base64 kodu
        public string Location { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
