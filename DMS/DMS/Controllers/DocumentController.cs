using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.Models;

namespace DMS.Controllers
{
    public class DocumentController : Controller
    {
        // GET: Document
        public ActionResult Index()
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.DCMNT_TBL.ToList());
            }
        }

        // GET: Document/Details/5
        public ActionResult Details(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.DCMNT_TBL.ToList().FirstOrDefault(p=>p.DCMT_ID==id));    
            }            
        }

        // GET: Document/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Document/Create
        [HttpPost]
        public ActionResult Create(DCMNT_TBL docModel, FormCollection collection)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    db.DCMNT_TBL.Add(docModel);
                    db.SaveChanges();
                    return RedirectToAction("Index",db.DCMNT_TBL.ToList());
                }                
            }
            catch
            {
                return View();
            }
        }

        // GET: Document/Edit/5
        public ActionResult Edit(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {                
                return View(db.DCMNT_TBL.ToList().FirstOrDefault(p=>p.DCMT_ID==id));
            }
            
        }

        // POST: Document/Edit/5
        [HttpPost]
        public ActionResult Edit(DCMNT_TBL docModel)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    var entry = db.Entry<DCMNT_TBL>(docModel);
                    if (entry.State.Equals(EntityState.Detached))
                    {
                        db.DCMNT_TBL.Attach(docModel);
                    }
                    entry.State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index",db.DCMNT_TBL.ToList());
                }                
            }
            catch
            {
                return View();
            }
        }

        // GET: Document/Delete/5
        public ActionResult Delete(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.DCMNT_TBL.ToList().FirstOrDefault(p=>p.DCMT_ID==id));
            }
            
        }

        // POST: Document/Delete/5
        [HttpPost]
        public ActionResult Delete(DCMNT_TBL docModel)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    var entry = db.Entry<DCMNT_TBL>(docModel);
                    entry.State=EntityState.Deleted;
                    db.DCMNT_TBL.ToList().RemoveAll(p => p.DCMT_ID == docModel.DCMT_ID);
                    db.SaveChanges();
                    return RedirectToAction("Index",db.DCMNT_TBL.ToList());
                }                
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DocumentScan()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult CreateScan(FormCollection fc, DCMNT_TBL dcmntTblModel)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    db.DCMNT_TBL.Add(dcmntTblModel );
                    db.SaveChanges();                    
                    ViewBag.Message = "Saved successfully";
                    return RedirectToAction("DocumentScan");
                }
            }
            catch
            {
                return View();
            }            
        }
    }
}
