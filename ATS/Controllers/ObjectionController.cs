using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATS.Data;
using ATS.Data.Models;
using ATS.Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReflectionIT.Mvc.Paging;

namespace ATS.Controllers
{
    public class ObjectionController : Controller
    {
        private readonly ATSDbContext db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManger;
        public readonly SignInManager<IdentityUser> _signInManager;
        public ObjectionController(RoleManager<IdentityRole> roleManager, ILogger<HomeController> logger, UserManager<IdentityUser> userManger, SignInManager<IdentityUser> signInManager, ATSDbContext db)
        {
            _logger = logger;
            _userManger = userManger;
            _signInManager = signInManager;
            this._roleManager = roleManager;
            this.db = db;
        }
        public async Task<IActionResult> Index(int page=1)
        {

            var qury =db.Objections.OrderBy(d=>d.mobileNo);
            var model = await PagingList.CreateAsync(qury,15,page);
            return View(model);

            //var qury = db.Objections;
            //var allmodaldata = qury.Select(c => new
            //{
            //    id = c.id,
            //    officialName = c.officialName,
            //    employeeId = c.employeeId,
            //    departmentId = c.departmentId,
            //    auditId = c.auditId,
            //    projectId = c.projectId,
            //    amount = c.amount,
            //    title = c.title,
            //    mobileNo = c.mobileNo,
            //    objectionType = c.objectionType,
            //    objectionsubmissionsDate = c.objectionsubmissionsDate,
            //    departmentName = db.Department.FirstOrDefault(p => p.id == c.departmentId) == null ? "" : db.Department.FirstOrDefault(p => p.id == c.departmentId).name,
            //    auditName = db.Audit.FirstOrDefault(p => p.id == c.auditId) == null ? "" : db.Audit.FirstOrDefault(p => p.id == c.auditId).name,
            //    projectName = db.Project.FirstOrDefault(p => p.id == c.projectId) == null ? "" : db.Project.FirstOrDefault(p => p.id == c.projectId).name,
            //}).OrderBy(d => d.mobileNo);
            //var model = await PagingList.CreateAsync(allmodaldata, 10, page);
            //return View(model);
        }

      

        public IActionResult Edit(int id)
        {
            if (id > 0)
            {
                ViewBag.Viewid = id;
                return View();
            }
            else
                return View();
        }

        public IActionResult CreateObjection()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateObjection([FromBody] Objection objection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objection.title == null || objection.title == "" || objection.officialName==null || objection.employeeId=="" || objection.employeeId==null||
                        objection.mobileNo == "" || objection.mobileNo==null || objection.email==null || objection.email=="" || objection.password=="" || objection.password==null
                        ||objection.dateofBirth==null||objection.dateofBirth==""||objection.departmentId==0 || objection.auditId==0||
                       objection.amount==0||objection.title==""||objection.title==null|| objection.projectId==0)
                    {
                        return Json("required");
                    }

                    var list = db.Objections.FirstOrDefault(b => b.officialName == objection.officialName && b.employeeId == objection.employeeId && b.email == objection.email && b.mobileNo == objection.mobileNo);
                    if (list != null)
                    {
                        if (list.title == objection.title)
                        {
                            return Json("title");
                        }                        
                    }
                    else
                    {
                        if (db.Objections.FirstOrDefault(b => b.officialName == objection.officialName) != null)
                        {
                            return Json("name");
                        }
                        if (db.Objections.FirstOrDefault(b => b.employeeId == objection.employeeId) != null)
                        {
                            return Json("employeeId");
                        }
                        if (db.Objections.FirstOrDefault(b => b.email == objection.email) != null)
                        {
                            return Json("email");
                        }
                        if (db.Objections.FirstOrDefault(b => b.mobileNo == objection.mobileNo) != null)
                        {
                            return Json("mobileNo");
                        }
                    }
                    
                    var user = new IdentityUser();
                    {
                        user.UserName = objection.employeeId;
                        user.Email = objection.email;
                        user.PhoneNumber = objection.mobileNo;
                    }
                    var result = await _userManger.CreateAsync(user, objection.password);
                    if (result.Succeeded)
                    {
                        RoleVM roleVM = new RoleVM();
                        roleVM.roleName ="User";
                        var role = _roleManager.FindByNameAsync(roleVM.roleName).Result;
                        if (role != null)
                        {
                            await _userManger.AddToRoleAsync(user, role.Name);
                        }
                    }
                    objection.statusProcess = "1";                               
                    db.Objections.Add(objection);
                    db.SaveChanges();
                    return Json("Done");                                     
                }
                catch (Exception ex)
                {
                    return Json("Failed" + ex);
                }
            }
            return Json("Failed");
            }

   
         

        [HttpGet]
        public IActionResult GetAll()
        {
            var GetAlldata = db.Objections;
            var Alldata= GetAlldata.Select(c => new
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
        public IActionResult Editobjection(int id)
        {
            var EditData = db.Objections.Find(id);
            return Json(EditData);
        }

      



        [HttpPost]
        public async Task<IActionResult> Update([FromBody] Objection objection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objection.title == null || objection.title == "" || objection.officialName == null || objection.employeeId == "" || objection.employeeId == null ||
                        objection.mobileNo == "" || objection.mobileNo == null || objection.email == null || objection.email == "" || objection.password == "" || objection.password == null
                        || objection.dateofBirth == null || objection.dateofBirth == "" || objection.departmentId == 0 || objection.auditId == 0 ||
                       objection.amount == 0 || objection.title == "" || objection.title == null || objection.projectId == 0)
                    {
                        return Json("required");
                    }

                    var list = db.Objections.FirstOrDefault(b => b.officialName == objection.officialName && b.employeeId == objection.employeeId && b.email == objection.email && b.mobileNo == objection.mobileNo && b.id != objection.id);
                    if (list != null)
                    {
                        if (list.title == objection.title)
                        {
                            return Json("title");
                        }
                    }
                    else
                    {
                        if (db.Objections.FirstOrDefault(b => b.officialName == objection.officialName && b.id != objection.id) != null)
                        {
                            return Json("name");
                        }
                        if (db.Objections.FirstOrDefault(b => b.employeeId == objection.employeeId && b.id != objection.id) != null)
                        {
                            return Json("employeeId");
                        }
                        if (db.Objections.FirstOrDefault(b => b.email == objection.email && b.id != objection.id) != null)
                        {
                            return Json("email");
                        }
                        if (db.Objections.FirstOrDefault(b => b.mobileNo == objection.mobileNo && b.id != objection.id) != null)
                        {
                            return Json("mobileNo");
                        }
                    }

                                  
                    Objection vm = db.Objections.Find(objection.id);
                    var user = await _userManger.FindByNameAsync(vm.employeeId);
                    if (user != null)
                    {
                        user.UserName = objection.employeeId;
                        user.Email = objection.email;
                        user.PhoneNumber = objection.mobileNo;
                        var result = await _userManger.UpdateAsync(user);
                    }
                    if (vm != null)
                    {
                        vm.officialName = objection.officialName;
                        vm.employeeId = objection.employeeId;
                        vm.departmentId = objection.departmentId;
                        vm.auditId = objection.auditId;
                        vm.projectId = objection.projectId;
                        vm.firstdesignation = objection.firstdesignation;
                        vm.currentdesignation = objection.currentdesignation;
                        vm.dateofBirth = objection.dateofBirth;
                        vm.years = objection.years;
                        vm.workplace = objection.workplace;
                        vm.upazilaId = objection.upazilaId;
                        vm.districtId = objection.districtId;                      
                        vm.description = objection.description;
                        vm.email = objection.email;
                        vm.amount = objection.amount;
                        vm.joiningDate = objection.joiningDate;
                        vm.auditobjectionsubmissionsDate = objection.auditobjectionsubmissionsDate;
                        vm.auditobjectioncreateDate = objection.auditobjectioncreateDate;
                        vm.title = objection.title;
                        vm.para = objection.para;                    
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
        public IActionResult Viewdata(int id)
        {
            if (id > 0)
            {
                ViewBag.Viewdata = id;
                return View();
            }
            else

                return View();
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
                departmentName = db.Department.FirstOrDefault(p => p.id == c.departmentId) == null ? "" : db.Department.FirstOrDefault(p => p.id == c.departmentId).name,
                auditName = db.Audit.FirstOrDefault(p => p.id == c.auditId) == null ? "" : db.Audit.FirstOrDefault(p => p.id == c.auditId).name,
                projectName = db.Project.FirstOrDefault(p => p.id == c.projectId) == null ? "" : db.Project.FirstOrDefault(p => p.id == c.projectId).name,
                divisionName = db.Division.FirstOrDefault(p => p.id == c.divisionId) == null ? "" : db.Division.FirstOrDefault(p => p.id == c.divisionId).name,
                districtName = db.District.FirstOrDefault(p => p.id == c.districtId) == null ? "" : db.District.FirstOrDefault(p => p.id == c.districtId).name,
                upazilaName = db.Upazila.FirstOrDefault(p => p.id == c.upazilaId) == null ? "" : db.Upazila.FirstOrDefault(p => p.id == c.upazilaId).name,

            }).FirstOrDefault();
            return Json(Alldataview);
         
        }
    }
}
