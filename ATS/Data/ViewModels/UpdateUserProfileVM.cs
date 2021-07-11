using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.Data.ViewModels
{
    public class UpdateUserProfileVM
    {
        public int id { get; set; }
        public string workplace { set; get; }
        public string firstdesignation { set; get; }
        public string currentdesignation { set; get; }
    }
}
