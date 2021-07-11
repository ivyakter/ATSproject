using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATS.Data;
using ATS.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATS.Controllers
{
    public class DivisionController : Controller
    {
        private readonly ATSDbContext db;
        public DivisionController(ATSDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Division division)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    if (division.name == null || division.name == "")
                    {
                        return Json("1");
                    }
                    if (db.Division.FirstOrDefault(d => d.name == division.name) != null)
                    {
                        return Json("2");
                    }
                    else
                        db.Division.Add(division);
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
            var list = db.Division;
            return Json(list);
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var list = db.Division.FirstOrDefault(d => d.id == id);
            return Json(list);
        }




        [HttpDelete]
        public ActionResult Remove(int id)
        {
            var deleteid = db.Division.Find(id);
            if (id > 0)
            {
                db.Division.Remove(deleteid);
                db.SaveChanges();
            }
            return Json(deleteid);
        }





        [HttpPost]
        public IActionResult Update([FromBody] Division division)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (division.name==null || division.name=="")
                    {
                        return Json("1");
                    }
                    if (db.Division.FirstOrDefault(g=>g.name==division.name&&g.id !=division.id) != null)
                    {
                        return Json("1");
                    }
                    Division vm = db.Division.Find(division.id);
                    if (vm !=null)
                    {
                        vm.name = division.name;
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
