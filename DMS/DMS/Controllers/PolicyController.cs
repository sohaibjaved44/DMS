using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.Models;

namespace DMS.Controllers
{
    public class PolicyController : Controller
    {
        // GET: Policy
        public ActionResult Index()
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.PLCY_TBL.ToList());
            }
        }

        // GET: Policy/Details/5
        public ActionResult Details(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.PLCY_TBL.FirstOrDefault(p=>p.Plcy_id==id));
            }
        }

        // GET: Policy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Policy/Create
        [HttpPost]
        public ActionResult Create(PLCY_TBL policyModel,FormCollection collection)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    db.PLCY_TBL.Add(policyModel);
                    db.SaveChanges();
                    return RedirectToAction("Index",db.PLCY_TBL.ToList());
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Policy/Edit/5
        public ActionResult Edit(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {                
                return View(db.PLCY_TBL.ToList().FirstOrDefault(p=>p.Plcy_id==id));
            }
        }

        // POST: Policy/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PLCY_TBL policyModel, FormCollection collection)
        {
            try
            {
                policyModel.Plcy_id = id;
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    var entry = db.Entry<PLCY_TBL>(policyModel);
                    if (entry.State.Equals(EntityState.Detached))
                    {
                        db.PLCY_TBL.Attach(policyModel);
                    }
                    entry.State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index",db.PLCY_TBL.ToList());
                }

                
            }
            catch
            {
                return View();
            }
        }

        // GET: Policy/Delete/5
        public ActionResult Delete(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.PLCY_TBL.ToList().FirstOrDefault(p=>p.Plcy_id==id));
            }
        }

        // POST: Policy/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PLCY_TBL policyModel, FormCollection collection)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    policyModel = db.PLCY_TBL.FirstOrDefault(p => p.Plcy_id == id);
                    var entry = db.Entry<PLCY_TBL>(policyModel);
                    entry.State = EntityState.Deleted;
                    db.PLCY_TBL.ToList().RemoveAll(p => p.Plcy_id == policyModel.Plcy_id);
                    db.SaveChanges();
                    return RedirectToAction("Index",db.PLCY_TBL.ToList());
                }   
            }
            catch
            {
                return View();
            }
        }
    }
}
