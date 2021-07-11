using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.Data.ViewModels
{
    public class ObjectionVM
    {
        public int id { set; get; }
        public int departmentId { set; get; }
        public int projectId { set; get; }
        public int auditId { set; get; }
        public int divisionId { set; get; }
        public int districtId { set; get; }
        public int upazilaId { set; get; }
        public string employeeId { set; get; }
        public string firstdesignation { set; get; }
        public string currentdesignation { set; get; }
        public string para { set; get; }
        public string title { set; get; }
        public string objectionType { set; get; }
        public string officialName { set; get; }
        public string joiningDate { set; get; }
        public string dateofBirth { set; get; }
        public string workplace { set; get; }
        public string mobileNo { set; get; }
        public string email { set; get; }
        public string years { set; get; }
        public double amount { set; get; }
        public string objectionsubmissionsDate { set; get; }
        public string auditobjectioncreateDate { set; get; }
        public string auditobjectionsubmissionsDate { set; get; }
        public string password { set; get; }
        public string statusProcess { set; get; }
        public string statusPending { set; get; }
        public string statusSettled { set; get; }
        public string description { set; get; }
        public string employeeReply { get; set; }
        public string employeeReplyDate { get; set; }
        public string auditFeetback { get; set; }
        public string auditFeetbackDate { get; set; }
        public string auditFeetbackPersonEmpId { get; set; }
        public string departmantName { get; set; }
    }
}
