using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.Data.ViewModels
{
    public class UserFilterVm
    {
        public int id { set; get; }
        public int departmentId { set; get; }
        public int auditId { set; get; }
        public int divisionId { set; get; }
        public int districtId { set; get; }
        public int upazilaId { set; get; }
        public string employeeId { set; get; }
        public string title { set; get; }
        public string officialName { set; get; }
        public string workplace { set; get; }
        public string mobileNo { set; get; }
        public string email { set; get; }
        public string years { set; get; }
        public double amount { set; get; }
        public string submissionStartDate { set; get; }
        public string submissionEndDate { set; get; }
        public string statusProcess { set; get; }
        public string statusPending { set; get; }
        public string statusSettled { set; get; }
    }
}
