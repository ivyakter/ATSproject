using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATS.Data;
using Microsoft.AspNetCore.Mvc;

namespace ATS.Controllers
{
    public class ReportController : Controller
    {
        private readonly ATSDbContext db;
        public ReportController(ATSDbContext db)
        {
            this.db = db;

        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Department()
        {
            var DepartmentList = db.Department.ToList();
            return Json(DepartmentList);
        }

    }
}
