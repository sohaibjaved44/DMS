using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.Models;

namespace DMS.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {

                return View(db.DEPT_TBL.ToList());
            }
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.DEPT_TBL.FirstOrDefault(p=>p.Dpt_id==id));
            }
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection,DEPT_TBL model)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    db.DEPT_TBL.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.DEPT_TBL.FirstOrDefault(p=>p.Dpt_id==id));
            }
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, DEPT_TBL model)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    var dept = db.DEPT_TBL.FirstOrDefault(p => p.Dpt_id == id);
                    if (dept != null)
                    {
                        var entry = db.Entry<DEPT_TBL>(model);
                        if (entry.State.Equals(EntityState.Detached))
                        {
                            db.DEPT_TBL.Attach(model);
                            
                        }
                        entry.State = EntityState.Modified;                                                    
                    }
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.DEPT_TBL.FirstOrDefault(p=>p.Dpt_id==id));
            }
        }

        // POST: Department/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,FormCollection formCollection)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    DEPT_TBL model = db.DEPT_TBL.FirstOrDefault(p => p.Dpt_id == id);
                    var entry = db.Entry<DEPT_TBL>(model);
                    entry.State = EntityState.Deleted;
                    db.DEPT_TBL.ToList().RemoveAll(p => p.Dpt_id == id);
                    db.SaveChanges();

                    return RedirectToAction("Index", db.DEPT_TBL.ToList());
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
