using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.Models;

namespace DMS.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {                
                return View(db.CTGRY_TBL.ToList());
            }
            
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.CTGRY_TBL.FirstOrDefault(p=>p.CtgryId==id));
            }
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CTGRY_TBL categoryModel)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    db.CTGRY_TBL.Add(categoryModel);
                    db.SaveChanges();


                    return RedirectToAction("Index",db.CTGRY_TBL.ToList());
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.CTGRY_TBL.FirstOrDefault(p=>p.CtgryId==id));
            }
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(CTGRY_TBL categoryModel)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    var entry = db.Entry<CTGRY_TBL>(categoryModel);
                    if (entry.State.Equals(EntityState.Detached))
                    {
                        db.CTGRY_TBL.Attach(categoryModel);
                    }
                    entry.State = EntityState.Modified;
                    db.SaveChanges();


                    return RedirectToAction("Index",db.CTGRY_TBL.ToList());
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.CTGRY_TBL.FirstOrDefault(p=>p.CtgryId==id));
            }            
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(CTGRY_TBL categoryModel)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    var entry = db.Entry<CTGRY_TBL>(categoryModel);
                    entry.State = EntityState.Deleted;
                    db.CTGRY_TBL.ToList().RemoveAll(p => p.CtgryId == categoryModel.CtgryId);
                    db.SaveChanges();
                    return RedirectToAction("Index", db.CTGRY_TBL.ToList());
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
