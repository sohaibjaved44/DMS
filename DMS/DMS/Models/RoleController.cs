using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMS.Models
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.ROLE_TBL.ToList());
            }
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.ROLE_TBL.FirstOrDefault(p=>p.ROLE_ID==id));
            }
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(ROLE_TBL roleModel)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    db.ROLE_TBL.Add(roleModel);
                    db.SaveChanges();
                    return RedirectToAction("Index",db.ROLE_TBL.ToList());
                }                
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.ROLE_TBL.FirstOrDefault(p=>p.ROLE_ID==id));
            }
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(ROLE_TBL roleModel)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    var entry = db.Entry<ROLE_TBL>(roleModel);
                    if (entry.State.Equals(EntityState.Detached))
                    {
                        db.ROLE_TBL.Attach(roleModel);
                    }
                    entry.State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", db.ROLE_TBL.ToList());
                }
            }
            catch (Exception ex)
            {
                return View(roleModel);
            }
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.ROLE_TBL.FirstOrDefault(p=>p.ROLE_ID==id));
            }
        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult Delete(ROLE_TBL roleModel)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    var entry = db.Entry<ROLE_TBL>(roleModel);
                    entry.State = EntityState.Deleted;
                    db.ROLE_TBL.ToList().RemoveAll(p => p.ROLE_ID == roleModel.ROLE_ID);
                    db.SaveChanges();
                    return RedirectToAction("Index",db.ROLE_TBL.ToList());
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
