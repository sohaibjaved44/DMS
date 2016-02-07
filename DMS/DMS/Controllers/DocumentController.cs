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
            if (Session["userid"] == null){return RedirectToAction("Login", "Account");}
            using (DMSDbEntities db = new DMSDbEntities())
            {
                Session["STRG_LOC"] = db.STRG_LOC_TBL.FirstOrDefault().STRG_LOC;
            }
            return View(new DCMNT_TBL(){FRST_NME = Session["fname"].ToString(),LAST_NME = Session["lname"].ToString()});
        }

        [HttpPost]
        public ActionResult CreateScan(FormCollection fc, DCMNT_TBL dcmntTblModel)
        {
            if (ModelState.IsValid)
            {
                string path = dcmntTblModel.STRG_LOC.Replace(@"\", "_");
                string[] parts = path.Split('_');
                string[] name = parts[parts.Length - 1].Split('.');
                try
                {
                    using (DMSDbEntities db = new DMSDbEntities())
                    {
                        dcmntTblModel.FILE_NME = name[0] + "." + name[1];
                        dcmntTblModel.USER_ID = Convert.ToInt32(Session["userid"]);
                        dcmntTblModel.SCAN_DTE = DateTime.Now.Date.ToString().Split(' ')[0];
                        dcmntTblModel.SCAN_TME = DateTime.Now.TimeOfDay.ToString().Split('.')[0];
                        db.DCMNT_TBL.Add(dcmntTblModel);
                        db.SaveChanges();
                        ViewBag.Message = "Saved successfully";
                        return RedirectToAction("DocumentScan");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Values not entered properly");
                    return View("DocumentScan", dcmntTblModel);
                }
            }
            else
            {
                ModelState.AddModelError("","Values not entered properly");
                return View("DocumentScan", dcmntTblModel);
            }
        }
    }
}
