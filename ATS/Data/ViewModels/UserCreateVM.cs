using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.Data.ViewModels
{
    public class UserCreateVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public string employeeId { get; set; }
        public string firstDesignation { set; get; }
        public string currentDesignation { set; get; }
        public string password { set; get; }
        public string userTypeId { set; get; }
        public string joiningDate { set; get; }
        public string dateofBirth { set; get; }
        public string workplace { set; get; }
        public string mobileNo { set; get; }
        public string email { set; get; }
        public string imageName { set; get; }
        public string imageLocation { set; get; }
        public bool activeStatus { set; get; }
        public string userCreateDate { set; get; }
        public int auditId { get; set; }
        public string userId { get; set; }
    }
}
