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
    [Authorize(Roles ="Admin")]
    public class DashboardController : Controller
    {
        private readonly ATSDbContext db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManger;
        public readonly SignInManager<IdentityUser> _signInManager;
        public DashboardController(RoleManager<IdentityRole> roleManager, ILogger<HomeController> logger, UserManager<IdentityUser> userManger, SignInManager<IdentityUser> signInManager, ATSDbContext db)
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
        
        public IActionResult AdminProfile()
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
                    UserDetails vm = db.UserDetails.FirstOrDefault(g => g.employeeId == user.UserName);
                    vm.password = model.ConfirmPassword;
                    db.Entry(vm).State = EntityState.Modified;
                    db.SaveChanges();
                    await _signInManager.RefreshSignInAsync(user);
                    return View("AdminProfile");
                }

            }

            return View(model);
        }
        [HttpGet]
        public IActionResult AdminprofileUpdate(string id)
        {
            var findid = db.UserDetails.FirstOrDefault(g => g.employeeId == id);
            return Json(findid);
        }
        [HttpGet]
        public IActionResult GetAdminPersonalInformation(string id)
        {
            var findid = db.UserDetails.Where(g => g.employeeId == id);
            var Alldata = findid.Select(c => new
            {
                id = c.id,
                name = c.name,
                employeeId = c.employeeId,
                dateofBirth = c.dateofBirth,
                firstDesignation = c.firstDesignation,
                currentDesignation = c.currentDesignation,
                email = c.email,
                mobileNo = c.mobileNo,
                mobiluserCreateDate = c.userCreateDate,
                joiningDate = c.joiningDate,
                workplace = c.workplace,
                userTypeId = c.userTypeId,
                userType = db.Roles.FirstOrDefault(p => p.Id == c.userTypeId) == null ? "" : db.Roles.FirstOrDefault(p => p.Id == c.userTypeId).Name,
            }).FirstOrDefault();
            return Json(Alldata);
         
        }
        [HttpPost]
        public IActionResult UpdateProfile([FromBody] UpdateUserProfileVM updateUserProfileVM)
        {
            var findId = db.UserDetails.Find(updateUserProfileVM.id);
            if (findId!=null)
            {
                findId.currentDesignation = updateUserProfileVM.currentdesignation;
                findId.firstDesignation = updateUserProfileVM.firstdesignation;
                findId.workplace = updateUserProfileVM.workplace;
                db.Entry(findId).State = EntityState.Modified;
                db.SaveChanges();
                return Json("Success");
            }

            return Json("NotFound");
        }
    }
}
