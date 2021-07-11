using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATS.Data;
using ATS.Data.Models;
using ATS.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ATS.Controllers
{
    [Authorize(Roles = "Audit")]
    public class AuditDashboardController : Controller
    {
        private readonly ATSDbContext db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManger;
        public readonly SignInManager<IdentityUser> _signInManager;
        public AuditDashboardController(RoleManager<IdentityRole> roleManager, ILogger<HomeController> logger, UserManager<IdentityUser> userManger, SignInManager<IdentityUser> signInManager, ATSDbContext db)
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

        public IActionResult Reply( int id)
        {
            if (id != 0)
            {
                ViewBag.Viewid = id;
                return View();
            }
            else
                return View();
        }
        public IActionResult ViewFeedback(int id)
        {
            if (id != 0)
            {
                ViewBag.ViewFeedbackId = id;
                return View();
            }
            else
                return View();
        }
        public IActionResult AuditProfile()
        {
            return View();
        }

        public IActionResult AllSubmission()
        {
            return View();
        }

        public IActionResult Feedback()
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManger.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("Login");
                }

                // ChangePasswordAsync changes the user password
                var result = await _userManger.ChangePasswordAsync(user,
                    model.CurrentPassword, model.NewPassword);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }

                // Upon successfully changing the password refresh sign-in cookie
                await _signInManager.RefreshSignInAsync(user);
                return View("ChangePasswordConfirmation");
            }

            return View(model);
        }



        [HttpGet]
        public IActionResult demo(string id)
        {
            var usergetone = _userManger.FindByNameAsync(id).Result;
            var userandaudit = db.AuditUserMapping.FirstOrDefault(b => b.userId == usergetone.Id);
            if (userandaudit != null)
            {
                var list = db.Objections.Where(d => d.auditId == userandaudit.auditId && d.auditFeetback == null && d.auditFeetbackPersonEmpId == null && d.auditFeetbackDate == null && d.employeeReply != null);
                if (list==null)
                {
                    return Json("NoObjectiuon");
                }
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
                return Json(Alldataview);

            }
            return Json("Audit");

        }


        [HttpGet]
        public IActionResult Allsubmissiongetdata(string id)
        {
            var usergettwo = _userManger.FindByNameAsync(id).Result;
            var getuserandaudit = db.AuditUserMapping.FirstOrDefault(b => b.userId == usergettwo.Id);
            if (getuserandaudit != null)
            {
                var list = db.Objections.Where(d => d.auditId == getuserandaudit.auditId);
                var Allsubmission = list.Select(c => new
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
                return Json(Allsubmission);
            }
            return Json("Audit");
        }


        [HttpGet]
        public IActionResult CategoryName(string id)
        {
            var usergetthree = _userManger.FindByNameAsync(id).Result;
            var Getuserandaudit = db.AuditUserMapping.FirstOrDefault(b => b.userId == usergetthree.Id);
            if (Getuserandaudit != null)
            {
                var list = db.Objections.Where(d => d.auditId == Getuserandaudit.auditId);
                var CategoryName = list.Select(c => new
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
                return Json(CategoryName);
            }
            return Json("Audit");
        }



        [HttpGet]
        public IActionResult AllFeedback(string id)
        {
            var usergetfourth = _userManger.FindByNameAsync(id).Result;
            var AllFeedbackgetuserandaudit = db.AuditUserMapping.FirstOrDefault(b => b.userId == usergetfourth.Id);
            if (AllFeedbackgetuserandaudit != null)
            {
                var list = db.Objections.Where(d => d.auditId == AllFeedbackgetuserandaudit.auditId &&d.auditFeetback !=null && d.auditFeetbackDate !=null&& d.auditFeetbackPersonEmpId != null);
                var AllFeedback = list.Select(c => new
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
                return Json(AllFeedback);
            }
            return Json("Audit");

        }


        [HttpGet]
        public IActionResult AllFeedbackList(string id)
        {
           
            var usergetfive = _userManger.FindByNameAsync(id).Result;
            var AllFeedbackListgetuserandaudit = db.AuditUserMapping.FirstOrDefault(b => b.userId == usergetfive.Id);
            if (AllFeedbackListgetuserandaudit != null)
            {
                var list = db.Objections.Where(d => d.auditId == AllFeedbackListgetuserandaudit.auditId && d.auditFeetback != null && d.auditFeetbackDate != null && d.auditFeetbackPersonEmpId != null);
                var AllFeedbackList = list.Select(c => new
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
                    auditFeetbackPersonId = c.auditFeetbackPersonEmpId,
                    departmentName = db.Department.FirstOrDefault(p => p.id == c.departmentId) == null ? "" : db.Department.FirstOrDefault(p => p.id == c.departmentId).name,
                    auditName = db.Audit.FirstOrDefault(p => p.id == c.auditId) == null ? "" : db.Audit.FirstOrDefault(p => p.id == c.auditId).name,
                    projectName = db.Project.FirstOrDefault(p => p.id == c.projectId) == null ? "" : db.Project.FirstOrDefault(p => p.id == c.projectId).name,
                    divisionName = db.Division.FirstOrDefault(p => p.id == c.divisionId) == null ? "" : db.Division.FirstOrDefault(p => p.id == c.divisionId).name,
                    districtName = db.District.FirstOrDefault(p => p.id == c.districtId) == null ? "" : db.District.FirstOrDefault(p => p.id == c.districtId).name,
                    upazilaName = db.Upazila.FirstOrDefault(p => p.id == c.upazilaId) == null ? "" : db.Upazila.FirstOrDefault(p => p.id == c.upazilaId).name,
                    userName=db.UserDetails.FirstOrDefault(p => p.employeeId== c.auditFeetbackPersonEmpId) == null ? "" : db.UserDetails.FirstOrDefault(p => p.employeeId == c.auditFeetbackPersonEmpId).name,
                }).ToList();
                return Json(AllFeedbackList);
            }
            return Json("Audit");

        }


        [HttpGet]
        public IActionResult AllFeedbackViewList(int id)
        {

                var list = db.Objections.Where(d => d.id ==id && d.auditFeetback != null && d.auditFeetbackDate != null && d.auditFeetbackPersonEmpId != null);
                var AllFeedbackViewList = list.Select(c => new
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
                    auditFeetbackPersonId = c.auditFeetbackPersonEmpId,
                    departmentName = db.Department.FirstOrDefault(p => p.id == c.departmentId) == null ? "" : db.Department.FirstOrDefault(p => p.id == c.departmentId).name,
                    auditName = db.Audit.FirstOrDefault(p => p.id == c.auditId) == null ? "" : db.Audit.FirstOrDefault(p => p.id == c.auditId).name,
                    projectName = db.Project.FirstOrDefault(p => p.id == c.projectId) == null ? "" : db.Project.FirstOrDefault(p => p.id == c.projectId).name,
                    divisionName = db.Division.FirstOrDefault(p => p.id == c.divisionId) == null ? "" : db.Division.FirstOrDefault(p => p.id == c.divisionId).name,
                    districtName = db.District.FirstOrDefault(p => p.id == c.districtId) == null ? "" : db.District.FirstOrDefault(p => p.id == c.districtId).name,
                    upazilaName = db.Upazila.FirstOrDefault(p => p.id == c.upazilaId) == null ? "" : db.Upazila.FirstOrDefault(p => p.id == c.upazilaId).name,
                    userName = db.UserDetails.FirstOrDefault(p => p.employeeId == c.auditFeetbackPersonEmpId) == null ? "" : db.UserDetails.FirstOrDefault(p => p.employeeId == c.auditFeetbackPersonEmpId).name,
                }).FirstOrDefault();
                return Json(AllFeedbackViewList);        
        }



        [HttpGet]
        public IActionResult notificationsaidbar(string id)
        {
            var userget = _userManger.FindByNameAsync(id).Result;
            var getuserandaudit = db.AuditUserMapping.FirstOrDefault(b => b.userId == userget.Id);
            if (getuserandaudit != null)
            {
                var list = db.Objections.Where(d => d.auditId == getuserandaudit.auditId && d.auditFeetback == null && d.auditFeetbackPersonEmpId == null && d.auditFeetbackDate==null&&d.employeeReply!=null);
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
                return Json(Alldataview);
            }
            return Json("Audit");
        }



        [HttpGet]
        public IActionResult fillterbyauditdata(int id)
        {
            var list = db.Objections.Where(d => d.id == id  && d.auditFeetback == null&&d.auditFeetbackPersonEmpId == null && d.auditFeetbackDate== null&&d.employeeReply != null);
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
                departmentName = db.Department.FirstOrDefault(p => p.id == c.departmentId) == null ? "" : db.Department.FirstOrDefault(p => p.id == c.departmentId).name,
                auditName = db.Audit.FirstOrDefault(p => p.id == c.auditId) == null ? "" : db.Audit.FirstOrDefault(p => p.id == c.auditId).name,
                projectName = db.Project.FirstOrDefault(p => p.id == c.projectId) == null ? "" : db.Project.FirstOrDefault(p => p.id == c.projectId).name,
                divisionName = db.Division.FirstOrDefault(p => p.id == c.divisionId) == null ? "" : db.Division.FirstOrDefault(p => p.id == c.divisionId).name,
                districtName = db.District.FirstOrDefault(p => p.id == c.districtId) == null ? "" : db.District.FirstOrDefault(p => p.id == c.districtId).name,
                upazilaName = db.Upazila.FirstOrDefault(p => p.id == c.upazilaId) == null ? "" : db.Upazila.FirstOrDefault(p => p.id == c.upazilaId).name,
            }).FirstOrDefault();
            return Json(Alldataview);

        }

        [HttpPost]
        public IActionResult ReplayAudit([FromBody] Objection objection)
        {
            if (ModelState.IsValid)
            {
                if (objection.reauditFeetbackPersonEmpId == "" || objection.auditFeetbackPersonEmpId == null)
                {
                    return Json("FeetbackPersonEmpId");
                }
                if (objection.reauditFeetback == "" || objection.auditFeetback == null)
                {
                    return Json("reauditFeetback");
                }
                Objection vm = db.Objections.Find(objection.id);
                if (vm != null)
                {
                    vm.auditFeetback = objection.auditFeetback;
                    vm.auditFeetbackDate = objection.auditFeetbackDate;
                    vm.auditFeetbackPersonEmpId = objection.auditFeetbackPersonEmpId;
                    if(objection.statusSettled=="3")
                    {
                        vm.statusPending =null;
                        vm.statusSettled = objection.statusSettled;
                    }
                    if(objection.statusSettled !="3")
                    {
                        vm.statusPending = objection.statusPending;
                        vm.statusSettled = null;
                    }
                 
                    db.Entry(vm).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json("Success");
                }
                return Json("NotFound");
            }
            return Json("InValid");
        }




        [HttpPost]
        public IActionResult RereplayAudit([FromBody] Objection objection)
        {
            if (ModelState.IsValid)
            {
                if (objection.statusSettled!="3")
                {
                    return Json("statusSettled");
                }
                if (objection.reauditFeetbackPersonEmpId =="" || objection.reauditFeetbackPersonEmpId==null)
                {
                    return Json("FeetbackPersonEmpId");
                }
                if (objection.reauditFeetback == "" || objection.reauditFeetback == null)
                {
                    return Json("reauditFeetback");
                }

                Objection vm = db.Objections.Find(objection.id);
                if (vm != null)
                {
                    vm.reauditFeetback = objection.reauditFeetback;
                    vm.reauditFeetbackDate = objection.reauditFeetbackDate;
                    vm.reauditFeetbackPersonEmpId = objection.reauditFeetbackPersonEmpId;
                    if (objection.statusSettled == "3")
                    {
                        vm.statusPending = null;                      
                    }                   
                    vm.statusSettled = objection.statusSettled;
                    db.Entry(vm).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json("Success");
                }
                return Json("NotFound");
            }
            return Json("InValid");
        }


        [HttpGet]
        public IActionResult profileView(string id)
        {
            var profile = db.UserDetails.Where(p => p.employeeId == id);
            var Alldata = profile.Select(c => new
            {
                id = c.id,
                name= c.name,
                employeeId= c.employeeId,
                dateofBirth= c.dateofBirth,
                firstDesignation=c.firstDesignation,
                currentDesignation= c.currentDesignation,
                email= c.email,
                mobileNo= c.mobileNo,
                mobiluserCreateDate =c.userCreateDate,
                joiningDate = c.joiningDate,
                workplace= c.workplace,
                userTypeId=c.userTypeId,
                userType = db.Roles.FirstOrDefault(p =>p.Id== c.userTypeId) == null ? "" : db.Roles.FirstOrDefault(p => p.Id == c.userTypeId).Name,
            }).FirstOrDefault();
            return Json(Alldata);
        }
        [HttpGet]
        public IActionResult AllfeedBackCount(string id)
        {
            var allfeedBackCount = db.Objections.Where(b=>b.auditFeetbackPersonEmpId==id);
            var finaldata = allfeedBackCount.Select(c => new
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
                auditFeetbackPersonEmpId = c.auditFeetbackPersonEmpId,
                 userName = db.UserDetails.FirstOrDefault(p => p.employeeId == c.auditFeetbackPersonEmpId) == null ? "" : db.UserDetails.FirstOrDefault(p => p.employeeId == c.auditFeetbackPersonEmpId).name,  
                departmentName = db.Department.FirstOrDefault(p => p.id == c.departmentId) == null ? "" : db.Department.FirstOrDefault(p => p.id == c.departmentId).name,
                auditName = db.Audit.FirstOrDefault(p => p.id == c.auditId) == null ? "" : db.Audit.FirstOrDefault(p => p.id == c.auditId).name,
                projectName = db.Project.FirstOrDefault(p => p.id == c.projectId) == null ? "" : db.Project.FirstOrDefault(p => p.id == c.projectId).name,
                divisionName = db.Division.FirstOrDefault(p => p.id == c.divisionId) == null ? "" : db.Division.FirstOrDefault(p => p.id == c.divisionId).name,
                districtName = db.District.FirstOrDefault(p => p.id == c.districtId) == null ? "" : db.District.FirstOrDefault(p => p.id == c.districtId).name,
                upazilaName = db.Upazila.FirstOrDefault(p => p.id == c.upazilaId) == null ? "" : db.Upazila.FirstOrDefault(p => p.id == c.upazilaId).name,

            }).ToList();
            return Json(finaldata);
        }
        [HttpGet]
        public IActionResult EditProfile(int id)
        {
            var findprofileid = db.UserDetails.Find(id);
            return Json(findprofileid);
        }
    }
}
