using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using ATS.Data;
using ATS.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATS.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ATSDbContext db;
        public DepartmentController(ATSDbContext db)
        {
            this.db =  db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Department department)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    if (department.name==null || department.name=="")
                    {
                        return Json("1");
                    }
                    if (db.Department.FirstOrDefault(d=>d.name==department.name) != null)
                    {
                        return Json("2");
                    }
                    else
                    db.Department.Add(department);
                    db.SaveChanges();
                    return Json("Success");
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
            var list = db.Department;
            return Json(list);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var list = db.Department.FirstOrDefault(d => d.id == id);
            return Json(list);
        }

      

        [HttpDelete]
        public ActionResult Remove(int id)
        {
            var deleteid = db.Department.Find(id);
            if (id > 0)
            {
                db.Department.Remove(deleteid);
                db.SaveChanges();
            }
            return Json(deleteid);
        }


        [HttpPost]
        public IActionResult Update([FromBody] Department department)
        {
            if (ModelState.IsValid)
            {


                try
                {
                    if (department.name == null || department.name == "")
                    {
                        return Json("1");
                    }
                    if (db.Department.FirstOrDefault(b => b.name == department.name && b.id != department.id) != null)
                    {
                        return Json("2");
                    }
                    Department vm = db.Department.Find(department.id);
                    if (vm != null)
                    {
                        vm.name = department.name;                  
                        db.Entry(vm).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                    return Json("Success");
                }
                catch (Exception ex)
                {
                    return Json("Failed" + ex);
                }

            }
            return Json("Failed");

        }


    }
}
