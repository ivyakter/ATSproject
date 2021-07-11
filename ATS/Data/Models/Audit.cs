using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.Data.Models
{
    public class Audit
    {
        public int id {set; get;}
        public string name { set; get; }
        public int departmentId { set; get; }
    }
}
