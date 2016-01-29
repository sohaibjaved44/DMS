using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.Models;

namespace DMS.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.USER_TBL.ToList());
            }            
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.USER_TBL.FirstOrDefault(p=>p.USER_ID==id));
            }            
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(USER_TBL userModel,FormCollection collection)
        {
            try
            {
                userModel.GNDR = (collection["GNDR"] == "Male") ? 1 : 2;
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    db.USER_TBL.Add(userModel);
                    db.SaveChanges();
                    return RedirectToAction("Index",db.USER_TBL.ToList());
                }
            }
            catch
            {
                return View(userModel);
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                try
                {
                    return View(db.USER_TBL.ToList().FirstOrDefault(p => p.USER_ID == id));
                }
                catch (Exception)
                {
                    return View();                    
                }
            }
            
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(USER_TBL userModel, FormCollection collection)
        {
            try
            {
                userModel.GNDR = (collection["GNDR"] == "Male") ? 1 : 2;
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    var entry = db.Entry<USER_TBL>(userModel);
                    if (entry.State.Equals(EntityState.Detached))
                    {
                        db.USER_TBL.Attach(userModel);
                    }
                    entry.State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index",db.USER_TBL.ToList());
                }                
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            using (DMSDbEntities db = new DMSDbEntities())
            {
                return View(db.USER_TBL.FirstOrDefault(p=>p.USER_ID==id));
            }            
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(USER_TBL userModel)
        {
            try
            {
                using (DMSDbEntities db = new DMSDbEntities())
                {
                    var entry = db.Entry<USER_TBL>(userModel);
                    entry.State = EntityState.Deleted;
                    db.USER_TBL.ToList().RemoveAll(p => p.USER_ID == userModel.USER_ID);
                    db.SaveChanges();
                    return RedirectToAction("Index",db.USER_TBL.ToList());
                }                
            }
            catch
            {
                return View();
            }
        }
    }
}
