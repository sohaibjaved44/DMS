using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.Models;

namespace DMS.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.PYMT_TBL.ToList());
            }
        }

        // GET: Payment/Details/5
        public ActionResult Details(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.PYMT_TBL.FirstOrDefault(p=>p.Pymt_id==id));
            }
        }

        // GET: Payment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Payment/Create
        [HttpPost]
        public ActionResult Create(PYMT_TBL paymentModel, FormCollection collection)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    db.PYMT_TBL.Add(paymentModel);
                    db.SaveChanges();
                    return RedirectToAction("Index", db.PYMT_TBL.ToList());
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Payment/Edit/5
        public ActionResult Edit(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.PYMT_TBL.ToList().FirstOrDefault(p => p.Pymt_id == id));
            }
        }

        // POST: Payment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PYMT_TBL paymentModel, FormCollection collection)
        {
            try
            {
                paymentModel.Pymt_id = id;
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    var entry = db.Entry<PYMT_TBL>(paymentModel);
                    if (entry.State.Equals(EntityState.Detached))
                    {
                        db.PYMT_TBL.Attach(paymentModel);
                    }
                    entry.State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", db.PYMT_TBL.ToList());
                }


            }
            catch
            {
                return View();
            }
        }

        // GET: Payment/Delete/5
        public ActionResult Delete(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.PYMT_TBL.ToList().FirstOrDefault(p => p.Pymt_id == id));
            }
        }

        // POST: Payment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PYMT_TBL paymentModel, FormCollection collection)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    paymentModel = db.PYMT_TBL.FirstOrDefault(p => p.Pymt_id == id);
                    var entry = db.Entry<PYMT_TBL>(paymentModel);
                    entry.State = EntityState.Deleted;
                    db.PYMT_TBL.ToList().RemoveAll(p => p.Pymt_id == paymentModel.Pymt_id);
                    db.SaveChanges();
                    return RedirectToAction("Index", db.PYMT_TBL.ToList());
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
