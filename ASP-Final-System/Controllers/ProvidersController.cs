using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_Final_System.Models;
using ASP_Final_System.ViewModel;

namespace ASP_Final_System.Controllers
{
    public class ProvidersController : Controller
    {
        private SystemModelContainer Database = new SystemModelContainer();

        // GET: Providers
        public ActionResult Index()
        {
            var Data = new SystemModels
            {
                Providers = Database.Providers.ToList(),
                Audits = Database.Audits.ToList()
            };
            return View(Data);
        }

        // GET: Providers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,RNC,Name,Phone,Email")] Providers providers)
        {
            if (ModelState.IsValid)
            {
                Database.Providers.Add(providers);
                Database.SaveChanges();
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
            Providers providers = Database.Providers.Find(id);
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
                Database.Entry(providers).State = EntityState.Modified;
                Database.SaveChanges();
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
            Providers providers = Database.Providers.Find(id);
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
            Providers providers = Database.Providers.Find(id);
            Database.Providers.Remove(providers);
            Database.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Database.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
