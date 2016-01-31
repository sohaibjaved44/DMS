using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.Models;

namespace DMS.Controllers
{
    public class ExtensionController : Controller
    {
        // GET: Extension
        public ActionResult Index()
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.EXTN_TBL.ToList());
            }
        }

        // GET: Extension/Details/5
        public ActionResult Details(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.EXTN_TBL.FirstOrDefault(p => p.EXTN_ID == id));
            }
        }

        // GET: Extension/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Extension/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection,EXTN_TBL extenTblModel)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    db.EXTN_TBL.Add(extenTblModel);
                    db.SaveChanges();
                    return RedirectToAction("Index", db.EXTN_TBL.ToList());
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Extension/Edit/5
        public ActionResult Edit(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.EXTN_TBL.ToList().FirstOrDefault(p => p.EXTN_ID == id));
            }
        }

        // POST: Extension/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection,EXTN_TBL extnTblModel)
        {
            try
            {
                extnTblModel.EXTN_ID = id;
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    var entry = db.Entry<EXTN_TBL>(extnTblModel);
                    if (entry.State.Equals(EntityState.Detached))
                    {
                        db.EXTN_TBL.Attach(extnTblModel);
                    }
                    entry.State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", db.EXTN_TBL.ToList());
                }


            }
            catch
            {
                return View();
            }
        }

        // GET: Extension/Delete/5
        public ActionResult Delete(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.EXTN_TBL.ToList().FirstOrDefault(p => p.EXTN_ID == id));
            }
        }

        // POST: Extension/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection,EXTN_TBL extnTblModel)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    extnTblModel = db.EXTN_TBL.FirstOrDefault(p => p.EXTN_ID == id);
                    var entry = db.Entry<EXTN_TBL>(extnTblModel);
                    entry.State = EntityState.Deleted;
                    db.EXTN_TBL.ToList().RemoveAll(p => p.EXTN_ID == extnTblModel.EXTN_ID);
                    db.SaveChanges();
                    return RedirectToAction("Index", db.EXTN_TBL.ToList());
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
