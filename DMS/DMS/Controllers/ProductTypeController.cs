using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.Models;

namespace DMS.Controllers
{
    public class ProductTypeController : Controller
    {
        // GET: ProductType
        public ActionResult Index()
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.PRDCT_TYPE.ToList());
            }
        }

        // GET: ProductType/Details/5
        public ActionResult Details(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.PRDCT_TYPE.FirstOrDefault(p => p.Product_type_id == id));
            }
        }

        // GET: ProductType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductType/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection,PRDCT_TYPE prdctTypeModel)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    db.PRDCT_TYPE.Add(prdctTypeModel);
                    db.SaveChanges();
                    return RedirectToAction("Index", db.PRDCT_TYPE.ToList());
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductType/Edit/5
        public ActionResult Edit(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.PRDCT_TYPE.ToList().FirstOrDefault(p => p.Product_type_id == id));
            }
        }

        // POST: ProductType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection,PRDCT_TYPE prdctTypeModel)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    var entry = db.Entry<PRDCT_TYPE>(prdctTypeModel);
                    if (entry.State.Equals(EntityState.Detached))
                    {
                        db.PRDCT_TYPE.Attach(prdctTypeModel);
                    }
                    entry.State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", db.PRDCT_TYPE.ToList());
                }


            }
            catch
            {
                return View();
            }
        }

        // GET: ProductType/Delete/5
        public ActionResult Delete(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.PRDCT_TYPE.ToList().FirstOrDefault(p => p.Product_type_id == id));
            }
        }

        // POST: ProductType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection,PRDCT_TYPE prdctTypeModel)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    prdctTypeModel = db.PRDCT_TYPE.FirstOrDefault(p => p.Product_type_id == id);
                    var entry = db.Entry<PRDCT_TYPE>(prdctTypeModel);
                    entry.State = EntityState.Deleted;
                    db.PRDCT_TYPE.ToList().RemoveAll(p => p.Product_type_id == prdctTypeModel.Product_type_id);
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
