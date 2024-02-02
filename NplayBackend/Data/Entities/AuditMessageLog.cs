using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojal.Data.Enitites
{
    public class AuditLog
    {
        public Guid Id { get; set; }
        public string Action { get; set; }
        public string PhoneNumber { get; set; }
        public string Data { get; set; }
        public DateTime Date { get; set; }

    }
}