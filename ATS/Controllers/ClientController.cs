using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATS.Data;
using ATS.Data.Models;
using ATS.Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReflectionIT.Mvc.Paging;

namespace ATS.Controllers
{

    public class ClientController : Controller
    {
        private readonly ATSDbContext db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManger;
        public readonly SignInManager<IdentityUser> _signInManager;
        public ClientController(RoleManager<IdentityRole> roleManager, ILogger<HomeController> logger, UserManager<IdentityUser> userManger, SignInManager<IdentityUser> signInManager, ATSDbContext db)
        {
            _logger = logger;
            _userManger = userManger;
            _signInManager = signInManager;
            this._roleManager = roleManager;
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Report()
        {
            return View();
        }

        public IActionResult swoSingalperson(string id)
        {
            if (id !=null)
            {
                ViewBag.Viewid = id;
                return View();
            }
            else
                return View();
        }


       
      
        [HttpGet]
        public IActionResult individualpersonlist(string id)
        {
            var test = db.Objections;
            var listtt = db.Objections.Where(d => d.employeeId ==id).ToList();

            var Alldataviewt = listtt.Select(c => new
            {

                id = c.id,
                officialName = c.officialName,
                employeeId = c.employeeId,
                departmentId = c.departmentId,
                auditId = c.auditId,
                projectId = c.projectId,
                firstdesignation = c.firstdesignation,
                currentdesignation = c.currentdesignation,
                dateofBirth = c.dateofBirth,
                years = c.years,
                workplace = c.workplace,
                upazilaId = c.upazilaId,
                divisionId = c.divisionId,
                districtId = c.districtId,
                description = c.description,
                email = c.email,
                amount = c.amount,
                joiningDate = c.joiningDate,
                auditobjectionsubmissionsDate = c.auditobjectionsubmissionsDate,
                auditobjectioncreateDate = c.auditobjectioncreateDate,
                title = c.title,
                para = c.para,
                password = c.password,
                statusProcess = c.statusProcess,
                statusPending = c.statusPending,
                statusSettled = c.statusSettled,
                employeeReply = c.employeeReply,
                employeeReplyDate = c.employeeReplyDate,
                auditFeetback = c.auditFeetback,
                auditFeetbackDate = c.auditFeetbackDate,
                mobileNo = c.mobileNo,
                departmentName = db.Department.FirstOrDefault(p => p.id == c.departmentId) == null ? "" : db.Department.FirstOrDefault(p => p.id == c.departmentId).name,
                auditName = db.Audit.FirstOrDefault(p => p.id == c.auditId) == null ? "" : db.Audit.FirstOrDefault(p => p.id == c.auditId).name,
                projectName = db.Project.FirstOrDefault(p => p.id == c.projectId) == null ? "" : db.Project.FirstOrDefault(p => p.id == c.projectId).name,
                divisionName = db.Division.FirstOrDefault(p => p.id == c.divisionId) == null ? "" : db.Division.FirstOrDefault(p => p.id == c.divisionId).name,
                districtName = db.District.FirstOrDefault(p => p.id == c.districtId) == null ? "" : db.District.FirstOrDefault(p => p.id == c.districtId).name,
                upazilaName = db.Upazila.FirstOrDefault(p => p.id == c.upazilaId) == null ? "" : db.Upazila.FirstOrDefault(p => p.id == c.upazilaId).name,

            }).ToList();
            return Json(Alldataviewt);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManger.FindByNameAsync(loginVM.UserName);
                if (user!=null)
                {
                    var roles = await _userManger.GetRolesAsync(user);
                    if (roles.Count != 0)
                    {
                        var rolename = roles[0];
                        if (rolename == "Audit" && user != null)
                        {
                            var signInresult = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                            if (signInresult.Succeeded)
                            { return RedirectToAction("Index", "AuditDashboard"); }
                            ModelState.AddModelError(string.Empty, "Username and Password do not Match");
                            return View();
                        }
                        if (rolename == "Admin" && user != null)
                        {
                            var signInresult = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                            if (signInresult.Succeeded)
                            { return RedirectToAction("Index", "Dashboard"); }
                            ModelState.AddModelError(string.Empty, "Username and Password do not Match");
                            return View();
                        }
                        if (rolename == "User" && user != null)
                        {
                            var signInresult = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                            if (signInresult.Succeeded)
                            {
                                return RedirectToAction("Index", "EmployeeProfile");
                            }
                            ModelState.AddModelError(string.Empty, "Username and Password do not Match");
                            return View();
                        }
                    }

                }
                ModelState.AddModelError(string.Empty, "Username Not Found");
                return View();
            }
            return View(loginVM);          
        }

        

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Client");
        }


        public IActionResult StatementofWorkingObjection (){

            return View();
        }

        [HttpGet]
        public IActionResult GetAllDepartmentforClientpage()
        {
            var list = db.Department;
            return Json(list);
        }
        
        [HttpGet]
        public IActionResult GetAllAuditforClientpage()
        {
            var GetAllAudit = db.Audit;
            return Json(GetAllAudit);
        }


        [HttpGet]
        public IActionResult GetAllProjectforClientpage()
        {
            var GetAllAudit = db.Project;
            return Json(GetAllAudit);
        }

        [HttpGet]
        public IActionResult GetAllDivisionforClientpage()
        {
            var GetAllDivision = db.Division;
            return Json(GetAllDivision);
        }


        [HttpGet]
        public IActionResult filterDistrict(int id)
        {
            var list = db.District.Where(d => d.divisionId == id).ToList();
            var fillterAlldata = list.Select(c => new
            {
                id = c.id,
                name = c.name,
                divisionId = c.divisionId,
                division = db.Division.FirstOrDefault(p => p.id == c.divisionId) == null ? "" : db.Division.FirstOrDefault(p => p.id == c.divisionId).name,

            }).ToList();
            return Json(fillterAlldata);
        }

        [HttpGet]
        public IActionResult filterUpazila(int id)
        {
            var list = db.Upazila.Where(d => d.districtId == id).ToList();
            var fillterAlldata = list.Select(c => new
            {
                id = c.id,
                name = c.name,
                districtId = c.districtId,
                district = db.District.FirstOrDefault(p => p.id == c.districtId) == null ? "" : db.District.FirstOrDefault(p => p.id == c.districtId).name,

            }).ToList();
            return Json(fillterAlldata);
        }

        [HttpGet]
        public IActionResult filterAudit(int id)
        {
            var list = db.Audit.Where(d => d.departmentId == id).ToList();
            var fillterAlldata = list.Select(c => new
            {
                id = c.id,
                name = c.name,
                departmentId = c.departmentId,
                departmentName = db.Department.FirstOrDefault(p => p.id == c.departmentId) == null ? "" : db.Department.FirstOrDefault(p => p.id == c.departmentId).name,

            }).ToList();
            return Json(fillterAlldata);
        }


        [HttpGet]
        public IActionResult ObjectionList()
        {
            var GetAlldata = db.Objections;
            var Alldata = GetAlldata.Select(c => new
            {
                id = c.id,
                officialName = c.officialName,
                employeeId = c.employeeId,
                departmentId = c.departmentId,
                auditId = c.auditId,
                projectId = c.projectId,
                firstdesignation = c.firstdesignation,
                currentdesignation = c.currentdesignation,
                dateofBirth = c.dateofBirth,
                years = c.years,
                workplace = c.workplace,
                upazilaId = c.upazilaId,
                divisionId = c.divisionId,
                districtId = c.districtId,
                description = c.description,
                email = c.email,
                amount = c.amount,
                joiningDate = c.joiningDate,
                auditobjectionsubmissionsDate = c.auditobjectionsubmissionsDate,
                auditobjectioncreateDate = c.auditobjectioncreateDate,
                title = c.title,
                para = c.para,
                password = c.password,
                statusProcess = c.statusProcess,
                statusPending = c.statusPending,
                statusSettled = c.statusSettled,
                mobileNo = c.mobileNo,
                objectionsubmissionsDate= c.objectionsubmissionsDate,
                departmentName = db.Department.FirstOrDefault(p => p.id == c.departmentId) == null ? "" : db.Department.FirstOrDefault(p => p.id == c.departmentId).name,
                auditName = db.Audit.FirstOrDefault(p => p.id == c.auditId) == null ? "" : db.Audit.FirstOrDefault(p => p.id == c.auditId).name,
                projectName = db.Project.FirstOrDefault(p => p.id == c.projectId) == null ? "" : db.Project.FirstOrDefault(p => p.id == c.projectId).name,
                divisionName = db.Division.FirstOrDefault(p => p.id == c.divisionId) == null ? "" : db.Division.FirstOrDefault(p => p.id == c.divisionId).name,
                districtName = db.District.FirstOrDefault(p => p.id == c.districtId) == null ? "" : db.District.FirstOrDefault(p => p.id == c.districtId).name,
                upazilaName = db.Upazila.FirstOrDefault(p => p.id == c.upazilaId) == null ? "" : db.Upazila.FirstOrDefault(p => p.id == c.upazilaId).name,


            }).ToList();
            return Json(Alldata);
        }
  
       [HttpGet]
        public IActionResult ObjectionStatementofWorkingObjectionList()
        {
            var GetAlldata = from p in db.Objections
                             group p by new { p.employeeId, p.officialName, p.mobileNo } into g
                             select new
                             {
                                 employeeId = g.Key.employeeId,
                                 officialName = g.Key.officialName,
                                 totalObjection = g.Count(),
                                 amount = g.Sum(g => g.amount),
                                 mobileNo = g.Key.mobileNo,
                                 prosessCount=g.Sum(p=>p.departmentId)

                             };
        

            return Json(GetAlldata);

            
        }


        [HttpGet]
        public IActionResult viewfilterdata(int id)
        {
            var list = db.Objections.Where(d => d.id == id);

            var Alldataview = list.Select(c => new
            {

                id = c.id,
                officialName = c.officialName,
                employeeId = c.employeeId,
                departmentId = c.departmentId,
                auditId = c.auditId,
                projectId = c.projectId,
                firstdesignation = c.firstdesignation,
                currentdesignation = c.currentdesignation,
                dateofBirth = c.dateofBirth,
                years = c.years,
                workplace = c.workplace,
                upazilaId = c.upazilaId,
                divisionId = c.divisionId,
                districtId = c.districtId,
                description = c.description,
                email = c.email,
                amount = c.amount,
                joiningDate = c.joiningDate,
                auditobjectionsubmissionsDate = c.auditobjectionsubmissionsDate,
                auditobjectioncreateDate = c.auditobjectioncreateDate,
                title = c.title,
                para = c.para,
                password = c.password,
                statusProcess = c.statusProcess,
                statusPending = c.statusPending,
                statusSettled = c.statusSettled,
                mobileNo = c.mobileNo,
                employeeReply = c.employeeReply,
                employeeReplyDate = c.employeeReplyDate,
                auditFeetback = c.auditFeetback,
                auditFeetbackDate = c.auditFeetbackDate,
                departmentName = db.Department.FirstOrDefault(p => p.id == c.departmentId) == null ? "" : db.Department.FirstOrDefault(p => p.id == c.departmentId).name,
                auditName = db.Audit.FirstOrDefault(p => p.id == c.auditId) == null ? "" : db.Audit.FirstOrDefault(p => p.id == c.auditId).name,
                projectName = db.Project.FirstOrDefault(p => p.id == c.projectId) == null ? "" : db.Project.FirstOrDefault(p => p.id == c.projectId).name,
                divisionName = db.Division.FirstOrDefault(p => p.id == c.divisionId) == null ? "" : db.Division.FirstOrDefault(p => p.id == c.divisionId).name,
                districtName = db.District.FirstOrDefault(p => p.id == c.districtId) == null ? "" : db.District.FirstOrDefault(p => p.id == c.districtId).name,
                upazilaName = db.Upazila.FirstOrDefault(p => p.id == c.upazilaId) == null ? "" : db.Upazila.FirstOrDefault(p => p.id == c.upazilaId).name,

            }).FirstOrDefault();
            return Json(Alldataview);

        }

        public IActionResult commondatalist(string id)
        {
            var list = db.Objections.Where(d => d.employeeId == id);
            var commondataview = list.Select(c => new
            {
                id = c.id,
                officialName = c.officialName,
                employeeId = c.employeeId,
                departmentId = c.departmentId,
                auditId = c.auditId,
                projectId = c.projectId,
                firstdesignation = c.firstdesignation,
                currentdesignation = c.currentdesignation,
                dateofBirth = c.dateofBirth,
                years = c.years,
                workplace = c.workplace,
                upazilaId = c.upazilaId,
                divisionId = c.divisionId,
                districtId = c.districtId,
                description = c.description,
                email = c.email,
                amount = c.amount,
                joiningDate = c.joiningDate,
                auditobjectionsubmissionsDate = c.auditobjectionsubmissionsDate,
                auditobjectioncreateDate = c.auditobjectioncreateDate,
                title = c.title,
                para = c.para,
                password = c.password,
                statusProcess = c.statusProcess,
                statusPending = c.statusPending,
                statusSettled = c.statusSettled,
                employeeReply = c.employeeReply,
                employeeReplyDate = c.employeeReplyDate,
                auditFeetback = c.auditFeetback,
                auditFeetbackDate = c.auditFeetbackDate,
                mobileNo = c.mobileNo,
                departmentName = db.Department.FirstOrDefault(p => p.id == c.departmentId) == null ? "" : db.Department.FirstOrDefault(p => p.id == c.departmentId).name,
                auditName = db.Audit.FirstOrDefault(p => p.id == c.auditId) == null ? "" : db.Audit.FirstOrDefault(p => p.id == c.auditId).name,
                projectName = db.Project.FirstOrDefault(p => p.id == c.projectId) == null ? "" : db.Project.FirstOrDefault(p => p.id == c.projectId).name,
                divisionName = db.Division.FirstOrDefault(p => p.id == c.divisionId) == null ? "" : db.Division.FirstOrDefault(p => p.id == c.divisionId).name,
                districtName = db.District.FirstOrDefault(p => p.id == c.districtId) == null ? "" : db.District.FirstOrDefault(p => p.id == c.districtId).name,
                upazilaName = db.Upazila.FirstOrDefault(p => p.id == c.upazilaId) == null ? "" : db.Upazila.FirstOrDefault(p => p.id == c.upazilaId).name,

            }).FirstOrDefault();
            return Json(commondataview);
        }

        [HttpGet]
        public IActionResult viewdata(int id)
        {
            var list = db.Objections.Where(d => d.id == id);
            var view = list.Select(c => new
            {
                id = c.id,
                officialName = c.officialName,
                employeeId = c.employeeId,
                departmentId = c.departmentId,
                auditId = c.auditId,
                projectId = c.projectId,
                firstdesignation = c.firstdesignation,
                currentdesignation = c.currentdesignation,
                dateofBirth = c.dateofBirth,
                years = c.years,
                workplace = c.workplace,
                upazilaId = c.upazilaId,
                divisionId = c.divisionId,
                districtId = c.districtId,
                description = c.description,
                email = c.email,
                amount = c.amount,
                joiningDate = c.joiningDate,
                auditobjectionsubmissionsDate = c.auditobjectionsubmissionsDate,
                auditobjectioncreateDate = c.auditobjectioncreateDate,
                title = c.title,
                para = c.para,
                password = c.password,
                statusProcess = c.statusProcess,
                statusPending = c.statusPending,
                statusSettled = c.statusSettled,
                employeeReply = c.employeeReply,
                employeeReplyDate = c.employeeReplyDate,
                auditFeetback = c.auditFeetback,
                auditFeetbackDate = c.auditFeetbackDate,
                mobileNo = c.mobileNo,
                departmentName = db.Department.FirstOrDefault(p => p.id == c.departmentId) == null ? "" : db.Department.FirstOrDefault(p => p.id == c.departmentId).name,
                auditName = db.Audit.FirstOrDefault(p => p.id == c.auditId) == null ? "" : db.Audit.FirstOrDefault(p => p.id == c.auditId).name,
                projectName = db.Project.FirstOrDefault(p => p.id == c.projectId) == null ? "" : db.Project.FirstOrDefault(p => p.id == c.projectId).name,
                divisionName = db.Division.FirstOrDefault(p => p.id == c.divisionId) == null ? "" : db.Division.FirstOrDefault(p => p.id == c.divisionId).name,
                districtName = db.District.FirstOrDefault(p => p.id == c.districtId) == null ? "" : db.District.FirstOrDefault(p => p.id == c.districtId).name,
                upazilaName = db.Upazila.FirstOrDefault(p => p.id == c.upazilaId) == null ? "" : db.Upazila.FirstOrDefault(p => p.id == c.upazilaId).name,

            }).FirstOrDefault();
            return Json(view);
        }

       [HttpPost]
        public IActionResult combinefilter([FromBody] UserFilterVm userFilterVm, int page = 1)
        {
            var data = db.Objections.ToList();
      
            if (userFilterVm != null)
            {
                if (userFilterVm.departmentId!=0)
                {
                    data = data.Where(d => d.departmentId == userFilterVm.departmentId).ToList();
                }
                if (userFilterVm.auditId !=0)
                {
                    data = data.Where(d => d.auditId == userFilterVm.auditId).ToList();
                }
                if (userFilterVm.years != "")
                {
                    data = data.Where(d => d.years == userFilterVm.years).ToList();
                }
                if (userFilterVm.divisionId != 0)
                {
                    data = data.Where(d => d.divisionId == userFilterVm.divisionId).ToList();
                }
                if (userFilterVm.districtId != 0)
                {
                    data = data.Where(d => d.districtId == userFilterVm.districtId).ToList();
                }
                if (userFilterVm.upazilaId != 0)
                {
                    data = data.Where(d => d.upazilaId == userFilterVm.upazilaId).ToList();
                }
                if (userFilterVm.submissionStartDate != null)
                {
                    data = data.Where(d => Convert.ToDateTime(d.objectionsubmissionsDate) >= Convert.ToDateTime(userFilterVm.submissionStartDate)).ToList();
                }
                if (userFilterVm.submissionEndDate != null)
                {
                    data = data.Where(d => Convert.ToDateTime(d.objectionsubmissionsDate) <= Convert.ToDateTime(userFilterVm.submissionEndDate)).ToList();
                }
                if (userFilterVm.mobileNo != null)
                {
                    data = data.Where(d => d.mobileNo== userFilterVm.mobileNo).ToList();
                }
            }
            var viewList = data.Select(c => new
            {
                id = c.id,
                officialName = c.officialName,
                employeeId = c.employeeId,
                departmentId = c.departmentId,
                auditId = c.auditId,
                projectId = c.projectId,
                firstdesignation = c.firstdesignation,
                currentdesignation = c.currentdesignation,
                dateofBirth = c.dateofBirth,
                years = c.years,
                workplace = c.workplace,
                upazilaId = c.upazilaId,
                divisionId = c.divisionId,
                districtId = c.districtId,
                email = c.email,
                amount = c.amount,  
                title = c.title,
                para = c.para,
                statusProcess = c.statusProcess,
                statusPending = c.statusPending,
                statusSettled = c.statusSettled,
                employeeReply = c.employeeReply,
                mobileNo = c.mobileNo,
                departmentName = db.Department.FirstOrDefault(p => p.id == c.departmentId) == null ? "" : db.Department.FirstOrDefault(p => p.id == c.departmentId).name,
                auditName = db.Audit.FirstOrDefault(p => p.id == c.auditId) == null ? "" : db.Audit.FirstOrDefault(p => p.id == c.auditId).name,
                projectName = db.Project.FirstOrDefault(p => p.id == c.projectId) == null ? "" : db.Project.FirstOrDefault(p => p.id == c.projectId).name,
            }).ToList();
            //var qury = viewList.OrderBy(c=>c.amount);
            //var model =await PagingList.CreateAsync(qury, 10, page);
            return Json(viewList);
        }



        [HttpPost]
        public IActionResult combinefilterinOtherPage([FromBody] UserFilterVm userFilterVm)
        {
            var data = db.Objections.ToList();

            if (userFilterVm != null)
            {
                if (userFilterVm.departmentId != 0)
                {
                    data = data.Where(d => d.departmentId == userFilterVm.departmentId).ToList();
                }
                if (userFilterVm.auditId != 0)
                {
                    data = data.Where(d => d.auditId == userFilterVm.auditId).ToList();
                }
                if (userFilterVm.years != "")
                {
                    data = data.Where(d => d.years == userFilterVm.years).ToList();
                }
                if (userFilterVm.divisionId != 0)
                {
                    data = data.Where(d => d.divisionId == userFilterVm.divisionId).ToList();
                }
                if (userFilterVm.districtId != 0)
                {
                    data = data.Where(d => d.districtId == userFilterVm.districtId).ToList();
                }
                if (userFilterVm.upazilaId != 0)
                {
                    data = data.Where(d => d.upazilaId == userFilterVm.upazilaId).ToList();
                }
                if (userFilterVm.submissionStartDate != null)
                {
                    data = data.Where(d => Convert.ToDateTime(d.objectionsubmissionsDate) >= Convert.ToDateTime(userFilterVm.submissionStartDate)).ToList();
                }
                if (userFilterVm.submissionEndDate != null)
                {
                    data = data.Where(d => Convert.ToDateTime(d.objectionsubmissionsDate) <= Convert.ToDateTime(userFilterVm.submissionEndDate)).ToList();
                }
                if (userFilterVm.mobileNo != null)
                {
                    data = data.Where(d => d.mobileNo == userFilterVm.mobileNo).ToList();
                }              
            }
            var GetAlldata = from p in data
                             group p by new { p.employeeId, p.officialName, p.mobileNo } into g
                             select new
                             {
                                 employeeId = g.Key.employeeId,
                                 officialName = g.Key.officialName,
                                 totalObjection = g.Count(),
                                 amount = g.Sum(g => g.amount),
                                 mobileNo = g.Key.mobileNo,
                                 prosessCount = g.Sum(p => p.departmentId)

                             };
            return Json(GetAlldata);
        }


    }
}
