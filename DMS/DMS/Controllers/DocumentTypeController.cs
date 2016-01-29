using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.Models;

namespace DMS.Controllers
{
    public class DocumentTypeController : Controller
    {
        // GET: DocumentType
        public ActionResult Index()
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.DCMT_TYPE.ToList());
            }
        }

        // GET: DocumentType/Details/5
        public ActionResult Details(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.DCMT_TYPE.FirstOrDefault(p => p.Dcmt_id == id));
            }
        }

        // GET: DocumentType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentType/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection,DCMT_TYPE dcmtTypeModel)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    db.DCMT_TYPE.Add(dcmtTypeModel);
                    db.SaveChanges();
                    return RedirectToAction("Index", db.DCMT_TYPE.ToList());
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: DocumentType/Edit/5
        public ActionResult Edit(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.DCMT_TYPE.ToList().FirstOrDefault(p => p.Dcmt_id == id));
            }
        }

        // POST: DocumentType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection,DCMT_TYPE dcmtTypeModl)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    var entry = db.Entry<DCMT_TYPE>(dcmtTypeModl);
                    if (entry.State.Equals(EntityState.Detached))
                    {
                        db.DCMT_TYPE.Attach(dcmtTypeModl);
                    }
                    entry.State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", db.DCMT_TYPE.ToList());
                }


            }
            catch
            {
                return View();
            }
        }

        // GET: DocumentType/Delete/5
        public ActionResult Delete(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.DCMT_TYPE.ToList().FirstOrDefault(p => p.Dcmt_id == id));
            }
        }

        // POST: DocumentType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection,DCMT_TYPE dcmtTypeModel)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    dcmtTypeModel = db.DCMT_TYPE.FirstOrDefault(p => p.Dcmt_id == id);
                    var entry = db.Entry<DCMT_TYPE>(dcmtTypeModel);
                    entry.State = EntityState.Deleted;
                    db.DCMT_TYPE.ToList().RemoveAll(p => p.Dcmt_id == dcmtTypeModel.Dcmt_id);
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
