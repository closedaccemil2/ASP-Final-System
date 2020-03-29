using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_Final_System.Models;

namespace ASP_Final_System.Controllers
{
    public class ProvidersController : Controller
    {
        private SystemModelContainer db = new SystemModelContainer();

        // GET: Providers
        public ActionResult Index()
        {
            return View(db.Providers.ToList());
        }

        // GET: Providers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Providers providers = db.Providers.Find(id);
            if (providers == null)
            {
                return HttpNotFound();
            }
            return View(providers);
        }

        // GET: Providers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Providers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RNC,Name,Phone,Email")] Providers providers)
        {
            if (ModelState.IsValid)
            {
                db.Providers.Add(providers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(providers);
        }

        // GET: Providers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Providers providers = db.Providers.Find(id);
            if (providers == null)
            {
                return HttpNotFound();
            }
            return View(providers);
        }

        // POST: Providers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RNC,Name,Phone,Email")] Providers providers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(providers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(providers);
        }

        // GET: Providers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Providers providers = db.Providers.Find(id);
            if (providers == null)
            {
                return HttpNotFound();
            }
            return View(providers);
        }

        // POST: Providers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Providers providers = db.Providers.Find(id);
            db.Providers.Remove(providers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
