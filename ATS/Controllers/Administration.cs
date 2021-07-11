using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATS.Data;
using ATS.Data.Models;
using ATS.Data.ViewModels;
using ATS.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ATS.Controllers
{

    public class Administration : Controller
    {
        private readonly ATSDbContext db;
      
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManger;
        public readonly SignInManager<IdentityUser> _signInManager;
        public Administration(RoleManager<IdentityRole> roleManager, ILogger<HomeController> logger, UserManager<IdentityUser> userManger, SignInManager<IdentityUser> signInManager, ATSDbContext db)
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


        public IActionResult Create()
        {
            return View();
        }


        //Create User

       [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateVM user)
        {
          
           
                    if (user.name == "" || user.name == null || user.employeeId == "" || user.employeeId == null ||
                        user.dateofBirth == "" || user.dateofBirth == null || user.mobileNo == "" || user.mobileNo == null ||
                        user.email == "" || user.email == null || user.joiningDate == "" || user.joiningDate == null)
                    {
                        return Json("required");
                    }
                    if (db.UserDetails.FirstOrDefault(s => s.mobileNo == user.mobileNo) != null)
                    {
                        return Json("mobileNo");
                    }

                    if (db.UserDetails.FirstOrDefault(s => s.employeeId == user.employeeId) != null)
                    {
                        return Json("employeeId");
                    }

                    if (db.UserDetails.FirstOrDefault(s => s.email == user.email) != null)
                    {
                        return Json("email");
                    }
                    var UserExit = await _userManger.FindByNameAsync(user.employeeId);
                    if (UserExit != null)
                    {
                        return Json("UserExit");

                    }
                    var auditUser = db.AuditUserMapping.FirstOrDefault(s => s.userId == user.userId);
                    if (auditUser != null)
                    {

                        return Json("UserandAuditExit");
                    }
                    else

               using (var scope = db.Database.BeginTransaction())
                     {

                try
                    {

                        var Newuser = new IdentityUser();
                        {
                            Newuser.UserName = user.employeeId;
                            Newuser.Email = user.email;
                            Newuser.PhoneNumber = user.mobileNo;
                        }
                        var result = await _userManger.CreateAsync(Newuser, user.password);
                        if (result.Succeeded)
                        {
                            var role = _roleManager.FindByIdAsync(user.userTypeId).Result;
                            if (role != null)
                            {
                                await _userManger.AddToRoleAsync(Newuser, role.Name);
                            }
                        }                    
                        var getUserId = await _userManger.FindByNameAsync(user.employeeId);
                        if (auditUser ==null)
                        {
                            AuditUserMapping auditUserMapping = new AuditUserMapping();
                            auditUserMapping.auditId = user.auditId;
                            auditUserMapping.userId = getUserId.Id;
                            db.AuditUserMapping.Add(auditUserMapping);
                            db.SaveChanges();
                        }
                    
                        UserDetails userDetails = new UserDetails();
                        userDetails.name = user.name;
                        userDetails.email = user.email;
                        userDetails.mobileNo = user.mobileNo;
                        userDetails.employeeId = user.employeeId;
                        userDetails.userTypeId = user.userTypeId;
                        userDetails.firstDesignation = user.firstDesignation;
                        userDetails.currentDesignation = user.currentDesignation;
                        userDetails.joiningDate = user.joiningDate;
                        userDetails.dateofBirth = user.dateofBirth;
                        userDetails.workplace = user.workplace;
                        userDetails.dateofBirth = user.dateofBirth;
                        userDetails.imageName = user.imageName;
                        userDetails.imageLocation = user.imageLocation;
                        userDetails.activeStatus = true;
                        userDetails.password = user.password;
                        db.UserDetails.Add(userDetails);
                        db.SaveChanges();
                        scope.Commit();
                        return Json("Success");
                    }

                    catch (Exception ex)
                    {
                        scope.Rollback();
                        return Json("Failed" + ex);
                    }

            }
        
        }




        [HttpGet]
        public IActionResult GetAllUser()
        {
            var allUser = db.UserDetails;
            var allroll= _roleManager.Roles;
            var getUser = allUser.Select(b => new
            {
                id=b.id,
                name=b.name,
                email=b.email,
                mobileNo = b.mobileNo,
                employeeId = b.employeeId,
                userTypeId = b.userTypeId,
               rolename= allroll.FirstOrDefault(p=>p.Id== b.userTypeId) == null ? "Empty Role" : allroll.FirstOrDefault(p => p.Id == b.userTypeId).Name,

            }).ToList();
            return Json(getUser);
        }


        [HttpGet]
        public IActionResult UserView(int id)
        {

            var allUser = db.UserDetails.Where(b=>b.id==id);
            var allroll = _roleManager.Roles;
            var getUser = allUser.Select(b => new
            {
                id = b.id,
                name = b.name,
                email = b.email,
                mobileNo = b.mobileNo,
                employeeId = b.employeeId,
                userTypeId = b.userTypeId,
                firstDesignation= b.firstDesignation,
                currentDesignation = b.currentDesignation,
                joiningDate = b.joiningDate,
                workplace = b.workplace,             
                dateofBirth = b.dateofBirth,
                activeStatus = b.activeStatus,
                rolename = allroll.FirstOrDefault(p => p.Id == b.userTypeId) == null ? "Empty Role" : allroll.FirstOrDefault(p => p.Id == b.userTypeId).Name,

            }).FirstOrDefault();
            return Json(getUser);
        }


        [HttpGet]
        public async Task<IActionResult> UserEdit(int id)
        {
            var list = db.UserDetails.FirstOrDefault(d => d.id == id);
            var getUserId = await _userManger.FindByNameAsync(list.employeeId);
            var auditId = db.AuditUserMapping.FirstOrDefault(d=>d.userId==getUserId.Id);
            UserCreateVM userCreateVM= new UserCreateVM();
            userCreateVM.id = list.id;
            userCreateVM.name = list.name;
            userCreateVM.mobileNo = list.mobileNo;
            userCreateVM.employeeId = list.employeeId;
            userCreateVM.userTypeId = list.userTypeId;
            userCreateVM.firstDesignation = list.firstDesignation;
            userCreateVM.currentDesignation = list.currentDesignation;
            userCreateVM.joiningDate = list.joiningDate;
            userCreateVM.workplace = list.workplace;
            userCreateVM.activeStatus = list.activeStatus;
            userCreateVM.workplace = list.workplace;
            userCreateVM.email = list.email;
            userCreateVM.dateofBirth = list.dateofBirth;
            if (auditId!=null)
            {
                userCreateVM.auditId = auditId.auditId;
            }
     
            
            return Json(userCreateVM);
        }


        [HttpPost]
        public async Task<IActionResult> updateuser([FromBody] UserCreateVM userDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (userDetails.name == "" || userDetails.name == null || userDetails.employeeId == "" || userDetails.employeeId == null ||
                        userDetails.dateofBirth == "" || userDetails.dateofBirth == null || userDetails.mobileNo == "" || userDetails.mobileNo == null ||
                        userDetails.email == "" || userDetails.email == null || userDetails.joiningDate == "" || userDetails.joiningDate == null)
                    {
                        return Json("required");
                    }

                    if (db.UserDetails.FirstOrDefault(s => s.employeeId == userDetails.employeeId && s.id != userDetails.id) != null)
                    {
                        return Json("employeeId");
                    }
                    if (db.UserDetails.FirstOrDefault(s => s.mobileNo == userDetails.mobileNo && s.id != userDetails.id) != null)
                    {
                        return Json("mobileNo");
                    }
                    if (db.UserDetails.FirstOrDefault(s => s.email == userDetails.email && s.id != userDetails.id) != null)
                    {
                        return Json("email");
                    }
                    var vm = db.UserDetails.Find(userDetails.id);
                    var user = await _userManger.FindByNameAsync(vm.employeeId);
                    if (user != null)
                    {
                        user.UserName = userDetails.employeeId;
                        user.Email = userDetails.email;
                        user.PhoneNumber = userDetails.mobileNo;
                        var result = await _userManger.UpdateAsync(user);


                        if (result.Succeeded)
                        {
                            var roles = await this._userManger.GetRolesAsync(user);
                            await this._userManger.RemoveFromRolesAsync(user, roles.ToArray());
                            //then add new role 
                            var roleName = await _roleManager.FindByIdAsync(userDetails.userTypeId);
                            await this._userManger.AddToRoleAsync(user, roleName.Name.ToString());
                        }
                        else
                        {
                            return Json("Failed");
                        }
                        
                    }
                    var getUserId =db.AuditUserMapping.FirstOrDefault(d=>d.userId==user.Id);                  
                    if (getUserId != null)
                    {

                        getUserId.auditId = userDetails.auditId;
                        getUserId.userId = user.Id;
                        db.Entry(getUserId).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    if (vm != null)
                    {
                        vm.name = userDetails.name;
                        vm.employeeId = userDetails.employeeId;
                        vm.firstDesignation = userDetails.firstDesignation;
                        vm.currentDesignation = userDetails.currentDesignation;
                        vm.dateofBirth = userDetails.dateofBirth;
                        vm.email = userDetails.email;
                        vm.imageLocation = userDetails.imageLocation;
                        vm.imageName = userDetails.imageName;
                        vm.joiningDate = userDetails.joiningDate;
                        vm.password = userDetails.password;
                        vm.userCreateDate = userDetails.userCreateDate;
                        vm.userTypeId = userDetails.userTypeId;
                        vm.workplace = userDetails.workplace;
                        vm.mobileNo = userDetails.mobileNo;
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
        [HttpDelete]
        public async Task<IActionResult> Removeuser(int id)
        {
        
            var deleteid = db.UserDetails.Find(id);
            var user = await _userManger.FindByNameAsync(deleteid.employeeId);
            var auditmapping = db.AuditUserMapping.FirstOrDefault(s=>s.userId==user.Id);
            if (id > 0)
            {
                db.UserDetails.Remove(deleteid);
                db.SaveChanges();
                db.AuditUserMapping.Remove(auditmapping);
                db.SaveChanges();
                var result=  await _userManger.DeleteAsync(user);
            }
            return Json(deleteid);

        }

            //Role Section


            public IActionResult Role()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody ]RoleVM role)
        {
            var roleExit = await _roleManager.RoleExistsAsync(role.roleName);
            if (!roleExit)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(role.roleName));
                return Json("Succeeded");
            }
            return Json("roleExit");
        }


        [HttpGet]
        public IActionResult GetAllRole()
        {
            var allrols = _roleManager.Roles;
            return Json(allrols);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var roleExit = await _roleManager.FindByIdAsync(id);
            return Json(roleExit);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole([FromBody] RoleVM role)
        {

         var roleExit = await _roleManager.RoleExistsAsync(role.roleName);
            if (!roleExit)
            {
                var roleFinnd = await _roleManager.FindByIdAsync(role.id);
                if (roleFinnd == null)
                {

                    return Json("NotFound");
                }
                else
                {
                    roleFinnd.Name = role.roleName;
                    var result = await _roleManager.UpdateAsync(roleFinnd);
                    if (result.Succeeded)
                    {
                        return Json("Succeeded");
                    }
                }

            }
          
            return Json("roleExit");
        }



        [HttpDelete]
        public async Task<IActionResult> Remove(string id)
        {
            var roleExit = await _roleManager.FindByIdAsync(id);
            if (roleExit == null)
            {
                return Json("NotFound");
            }
            else
            {
               var result = await _roleManager.DeleteAsync(roleExit);
                if (result.Succeeded)
                {
                    var updateUsertype = db.UserDetails.FirstOrDefault(n => n.userTypeId == id);
                    if (updateUsertype != null)
                    {
                        updateUsertype.userTypeId = null;
                        updateUsertype.activeStatus=false;
                        db.Entry(updateUsertype).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Json("Succeeded");
                }
            }             
            return Json("NotFound");
        }

    }
}
