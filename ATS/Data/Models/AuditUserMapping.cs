using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.Data.Models
{
    public class AuditUserMapping
    {
        public int id { get; set; }
        public int auditId { get; set; }
        public string userId { get; set; }
    }
}
