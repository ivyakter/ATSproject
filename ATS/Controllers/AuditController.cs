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
    //[Authorize(Roles = "Audit")]
    public class AuditController : Controller
    {
        private readonly ATSDbContext db;
        public AuditController(ATSDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromBody] Audit audit)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    if (audit.name==null || audit.name=="")
                    {
                        return Json("1");
                    }

                    if (db.Audit.FirstOrDefault(a => a.name == audit.name) != null)
                    {
                        return Json("2");
                    }
                    else
                     db.Audit.Add(audit);
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
            var list = db.Audit;
            var Alldata = list.Select(c => new
            {
                id = c.id,
                name = c.name,
                departmentId = c.departmentId,
                departmentName = db.Department.FirstOrDefault(p => p.id == c.departmentId) == null ? "" : db.Department.FirstOrDefault(p => p.id == c.departmentId).name,

            }).ToList();
            return Json(Alldata);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var list = db.Audit.FirstOrDefault(d => d.id == id);
            return Json(list);
        }


        [HttpDelete]
        public ActionResult Remove(int id)
        {
            var deleteid = db.Audit.Find(id);
            if (id > 0)
            {
                db.Audit.Remove(deleteid);
                db.SaveChanges();
            }
            return Json(deleteid);
        }

        [HttpGet]
        public IActionResult filter(int id)
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


        [HttpPost]
        public IActionResult Update([FromBody] Audit audit)
        {
            if (ModelState.IsValid)
            {


                try
                {
                    if (audit.name == null || audit.name == "")
                    {
                        return Json("1");
                    }
                    if (db.Audit.FirstOrDefault(b => b.name == audit.name && b.id != audit.id) != null)
                    {
                        return Json("2");
                    }
                    Audit vm = db.Audit.Find(audit.id);
                    if (vm != null)
                    {
                        vm.name = audit.name;
                        vm.departmentId = audit.departmentId;
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
