using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATS.Data;
using ATS.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace ATS.Controllers
{
    public class UpzilaController : Controller
    {
        private readonly ATSDbContext db;
        public UpzilaController(ATSDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            var qury = db.Upazila.OrderBy(d => d.id);
            var model = await PagingList.CreateAsync(qury, 10, page);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> get(int page = 1)
        {
            var qury = db.Upazila.OrderBy(d => d.id);
            var model = await PagingList.CreateAsync(qury, 10, page);
            return Json(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Upazila upzila)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (upzila.name == null || upzila.name == "")
                    {
                        return Json("1");
                    }
                    if (db.Upazila.FirstOrDefault(d => d.name == upzila.name) != null)
                    {
                        return Json("2");
                    }
                    else
                        db.Upazila.Add(upzila);
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
            var list = db.Upazila;
            return Json(list);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var editId = db.Upazila.FirstOrDefault(edit => edit.id == id);
            return Json(editId);
        
        }


        [HttpDelete]
        public ActionResult Remove(int id)
        {
            var deleteid = db.Upazila.Find(id);
            if (id > 0)
            {
                db.Upazila.Remove(deleteid);
                db.SaveChanges();
            }
            return Json(deleteid);
        }


        [HttpPost]
        public IActionResult Update([FromBody] Upazila upzila)
        {
            if (ModelState.IsValid)
            {


                try
                {
                    if (upzila.name == null || upzila.name == "")
                    {
                        return Json("1");
                    }
                    if (db.Upazila.FirstOrDefault(b => b.name == upzila.name && b.id != upzila.id) != null)
                    {
                        return Json("2");
                    }
                    Upazila vm = db.Upazila.Find(upzila.id);
                    if (vm != null)
                    {
                        vm.name = upzila.name;
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
            var list = db.Upazila.Where(d => d.districtId == id).ToList();
            var fillterAlldata = list.Select(c => new
            {
                id = c.id,
                name = c.name,
                districtId = c.districtId,
                banglaName = c.banglaName,
                District = db.District.FirstOrDefault(p => p.id == c.districtId) == null ? "" : db.District.FirstOrDefault(p => p.id == c.districtId).name,

            }).ToList();
            return Json(fillterAlldata);
        }


    }
}
