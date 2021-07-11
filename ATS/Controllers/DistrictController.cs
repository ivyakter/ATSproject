using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using ATS.Data;
using ATS.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace ATS.Controllers
{
    public class DistrictController : Controller

    {
        private readonly ATSDbContext db;
        public DistrictController(ATSDbContext db)
        {
            this.db =db;
        }
        

        public async Task<IActionResult> Index(int page = 1)
        {
            var qury = db.District.OrderBy(d => d.id);
            var model = await PagingList.CreateAsync(qury, 10, page);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> get(int page = 1)
        {
            var qury = db.District.OrderBy(d => d.id);
            var model = await PagingList.CreateAsync(qury, 10, page);
            return Json(model);
        }


        [HttpPost]
        public IActionResult Create([FromBody] District district)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (district.name == null || district.name == "")
                    {
                        return Json("1");
                    }
                    if (db.District.FirstOrDefault(b => b.name == district.name) != null)
                    {
                        return Json("2");
                    }
                    else
                        db.District.Add(district);
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
            var list = db.District;
            return Json(list);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var list = db.District.FirstOrDefault(d => d.id == id);
            return Json(list);
        }


        [HttpDelete]
        public ActionResult Remove(int id)
        {
            var deleteId = db.District.Find(id);
            if (id>0)
            {
                db.District.Remove(deleteId);
                db.SaveChanges();

            }
            return Json(deleteId);
        }

        [HttpPost]
        public IActionResult Update([FromBody] District district)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    if (district.name == null || district.name == "")
                    {
                        return Json("1");
                    }
                    if (db.District.FirstOrDefault(n => n.name == district.name && n.id != district.id) != null)
                    {
                        return Json("2");
                    }

                    District vm = db.District.Find(district.id);
                    if (vm != null)
                    {
                        vm.name = district.name;
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


        [HttpGet]
        public IActionResult filter(int id)
        {
            var list = db.District.Where(d => d.divisionId == id).ToList();
            var fillterAlldata = list.Select(c => new
            {
                id = c.id,
                name = c.name,
                divisionId = c.divisionId,
                banglaName= c.banglaName,
                division= db.Division.FirstOrDefault(p => p.id == c.divisionId) == null ? "" : db.Division.FirstOrDefault(p => p.id == c.divisionId).name,

            }).ToList();
            return Json(fillterAlldata);
        }



    }
}
