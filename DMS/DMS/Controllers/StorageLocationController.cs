using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.Models;

namespace DMS.Controllers
{
    public class StorageLocationController : Controller
    {
        // GET: StorageLocation
        public ActionResult Index()
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.STRG_LOC_TBL.ToList());
            }
        }

        // GET: StorageLocation/Details/5
        public ActionResult Details(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.STRG_LOC_TBL.FirstOrDefault(p => p.STRG_ID == id));
            }
        }

        // GET: StorageLocation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StorageLocation/Create
        [HttpPost]
        public ActionResult Create(STRG_LOC_TBL storageModel, FormCollection collection)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    db.STRG_LOC_TBL.Add(storageModel);
                    db.SaveChanges();
                    return RedirectToAction("Index", db.STRG_LOC_TBL.ToList());
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: StorageLocation/Edit/5
        public ActionResult Edit(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.STRG_LOC_TBL.ToList().FirstOrDefault(p => p.STRG_ID == id));
            }
        }

        // POST: StorageLocation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,STRG_LOC_TBL storageModel, FormCollection collection)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    storageModel.STRG_ID = id;
                    var entry = db.Entry<STRG_LOC_TBL>(storageModel);
                    if (entry.State.Equals(EntityState.Detached))
                    {
                        db.STRG_LOC_TBL.Attach(storageModel);
                    }
                    entry.State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", db.STRG_LOC_TBL.ToList());
                }


            }
            catch
            {
                return View();
            }
        }

        // GET: StorageLocation/Delete/5
        public ActionResult Delete(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.STRG_LOC_TBL.ToList().FirstOrDefault(p => p.STRG_ID == id));
            }
        }

        // POST: StorageLocation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, STRG_LOC_TBL storageModel, FormCollection collection)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    storageModel = db.STRG_LOC_TBL.FirstOrDefault(p => p.STRG_ID == id);
                    var entry = db.Entry<STRG_LOC_TBL>(storageModel);
                    entry.State = EntityState.Deleted;
                    db.STRG_LOC_TBL.ToList().RemoveAll(p => p.STRG_ID == storageModel.STRG_ID);
                    db.SaveChanges();
                    return RedirectToAction("Index", db.STRG_LOC_TBL.ToList());
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
