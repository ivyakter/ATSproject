using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATS.Data;
using ATS.Data.Models;
using ATS.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ATS.Controllers
{
    [Authorize(Roles = "User")]
    public class EmployeeProfileController : Controller
    {
        private readonly ATSDbContext db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManger;
        public readonly SignInManager<IdentityUser> _signInManager;
        public EmployeeProfileController(RoleManager<IdentityRole> roleManager, ILogger<HomeController> logger, UserManager<IdentityUser> userManger, SignInManager<IdentityUser> signInManager, ATSDbContext db)
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

        public IActionResult EMP()
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
                if (result.Succeeded)
                {
                    Objection vm = db.Objections.FirstOrDefault(g => g.employeeId == user.UserName);
                    vm.password = model.ConfirmPassword;
                    db.Entry(vm).State = EntityState.Modified;
                    db.SaveChanges();
                    await _signInManager.RefreshSignInAsync(user);
                    return View("Index");
                }

            }

            return View(model);
        }

        [HttpGet]
        public IActionResult NewObjectionGet(string id)
        {

            var list = db.Objections.Where(d => d.employeeId == id && d.statusProcess=="1" && d.employeeReply==null);

            var Objectionview = list.Select(c => new
            {
                id = c.id,
                officialName = c.officialName,
                employeeId = c.employeeId,
                departmentId = c.departmentId,
                auditId = c.auditId,
                projectId = c.projectId,
                email = c.email,
                amount = c.amount,
                title = c.title,
                para = c.para,
                mobileNo = c.mobileNo,
                departmentName = db.Department.FirstOrDefault(p => p.id == c.departmentId) == null ? "" : db.Department.FirstOrDefault(p => p.id == c.departmentId).name,
                auditName = db.Audit.FirstOrDefault(p => p.id == c.auditId) == null ? "" : db.Audit.FirstOrDefault(p => p.id == c.auditId).name,
                projectName = db.Project.FirstOrDefault(p => p.id == c.projectId) == null ? "" : db.Project.FirstOrDefault(p => p.id == c.projectId).name,
            }).ToList();
            return Json(Objectionview);
        }

        [HttpGet]
        public IActionResult ReplyObjection(int id)
        {

            var list = db.Objections.Where(d => d.id == id && d.statusProcess == "1" && d.employeeReply == null);

            var replyObjection = list.Select(c => new
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
            return Json(replyObjection);
        }

        [HttpGet]
        public IActionResult commondataGet(string id)
        {
            var list = db.Objections.Where(d => d.employeeId == id);
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

            }).FirstOrDefault();
            return Json(Alldataview);
        }


        [HttpPost]
        public IActionResult Update([FromBody] Objection objection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Objection vm = db.Objections.FirstOrDefault(d=>d.title==objection.title);
                    if (vm != null ||vm.employeeReply==""||vm.employeeReply==null||vm.employeeReplyDate==""||vm.employeeReplyDate==null)
                    {
                        vm.employeeId = objection.employeeId;
                        vm.employeeReply = objection.employeeReply;
                        vm.employeeReplyDate = objection.employeeReplyDate;
                        vm.statusProcess = "";
                        vm.statusPending = "2";
                        db.Entry(vm).State = EntityState.Modified;
                        db.SaveChanges();
                        return Json("Success");
                    }               
                }

                catch (Exception ex)
                {
                    return Json("Failed" + ex);
                }
            }

            return Json("Failed");
        }

        [HttpGet]
        public IActionResult CountObjection(string id)
        {
            var countobjection = db.Objections.Where(k=>k.employeeId==id);

            var countobjectionview = countobjection.Select(c => new
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
            return Json(countobjectionview);

            
        }
        [HttpGet]
        public IActionResult ProcessofObjection(string id)
        {
            var statusProcess = db.Objections.Where(k => k.employeeId == id && k.statusProcess=="1").ToList();
            return Json(statusProcess);
        }

        [HttpGet]
        public IActionResult PendingofObjection(string id)
        {
            var statusPending = db.Objections.Where(k => k.employeeId == id && k.statusPending == "2").ToList();
            return Json(statusPending);
        }

        [HttpGet]
        public IActionResult SettledofObjection(string id)
        {
            var statusSettled = db.Objections.Where(k => k.employeeId == id && k.statusSettled == "3").ToList();
            return Json(statusSettled);
        }

        [HttpGet]
        public IActionResult profileUpdate(string id)
        {
            var findid = db.Objections.FirstOrDefault(g=>g.employeeId==id);
            return Json(findid);
        }

        [HttpPost]
        public IActionResult Updateprofile([FromBody] UpdateUserProfileVM updateUserProfileVM)
        {
            var vm = db.Objections.Find(updateUserProfileVM.id);
            if (vm!=null)
            {
                vm.currentdesignation = updateUserProfileVM.currentdesignation;
                vm.firstdesignation = updateUserProfileVM.firstdesignation;
                vm.workplace = updateUserProfileVM.workplace;
                db.Entry(vm).State = EntityState.Modified;
                db.SaveChanges();
               return Json("Success");
        }
            return Json("NotFound");
        }
    }
}
