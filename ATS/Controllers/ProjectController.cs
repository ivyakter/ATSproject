using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATS.Data;
using ATS.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATS.Controllers
{
 
    public class ProjectController : Controller
    {
        private readonly ATSDbContext db;
        public ProjectController(ATSDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Project project )
        {
            if (ModelState.IsValid)
            {

                try
                {
                    if (project.name == null || project.name == "")
                    {
                        return Json("1");
                    }
                    if (db.Project.FirstOrDefault(d => d.name == project.name) != null)
                    {
                        return Json("2");
                    }
                    else
                        db.Project.Add(project);
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
            var list = db.Project;
            return Json(list);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var list = db.Project.FirstOrDefault(d => d.id == id);
            return Json(list);
        }



        [HttpDelete]
        public ActionResult Remove(int id)
        {
            var deleteid = db.Project.Find(id);
            if (id > 0)
            {
                db.Project.Remove(deleteid);
                db.SaveChanges();
            }
            return Json(deleteid);
        }

        [HttpPost]
        public IActionResult Update([FromBody] Project project )
        {
            if (ModelState.IsValid)
            {


                try
                {
                    if (project.name == null || project.name == "")
                    {
                        return Json("1");
                    }
                    if (db.Project.FirstOrDefault(b => b.name == project.name && b.id != project.id) != null)
                    {
                        return Json("2");
                    }
                    Project vm = db.Project.Find(project.id);
                    if (vm != null)
                    {
                        vm.name = project.name;
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
