using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.Models;

namespace DMS.Controllers
{
    public class PlanController : Controller
    {
        // GET: Plan
        public ActionResult Index()
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.PLAN_TBL.ToList());
            }
        }

        // GET: Plan/Details/5
        public ActionResult Details(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.PLAN_TBL.FirstOrDefault(p => p.Plan_id == id));
            }
        }

        // GET: Plan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plan/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection,PLAN_TBL planModel)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    db.PLAN_TBL.Add(planModel);
                    db.SaveChanges();
                    return RedirectToAction("Index", db.PLAN_TBL.ToList());
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Plan/Edit/5
        public ActionResult Edit(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.PLAN_TBL.ToList().FirstOrDefault(p => p.Plan_id == id));
            }
        }

        // POST: Plan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,PLAN_TBL planModel, FormCollection collection)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    var entry = db.Entry<PLAN_TBL>(planModel);
                    if (entry.State.Equals(EntityState.Detached))
                    {
                        db.PLAN_TBL.Attach(planModel);
                    }
                    entry.State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", db.PLAN_TBL.ToList());
                }


            }
            catch
            {
                return View();
            }
        }

        // GET: Plan/Delete/5
        public ActionResult Delete(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.PLAN_TBL.ToList().FirstOrDefault(p => p.Plan_id == id));
            }
        }

        // POST: Plan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PLAN_TBL planModel, FormCollection collection)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    planModel = db.PLAN_TBL.FirstOrDefault(p => p.Plan_id == id);
                    var entry = db.Entry<PLAN_TBL>(planModel);
                    entry.State = EntityState.Deleted;
                    db.PLAN_TBL.ToList().RemoveAll(p => p.Plan_id == planModel.Plan_id);
                    db.SaveChanges();
                    return RedirectToAction("Index", db.PLAN_TBL.ToList());
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
