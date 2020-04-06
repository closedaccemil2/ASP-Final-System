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
    public class ClientsController : Controller
    {
        private readonly SystemModelContainer Database = new SystemModelContainer();

        // GET: Clients
        public ActionResult Index()
        {
            var Data = new SystemModels
            {
                Clients = Database.Clients.ToList(),
                Audits = Database.Audits.ToList()
            };
            return View(Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,RNC,Name,Phone,Email,Category")] Clients clients)
        {
            if (ModelState.IsValid)
            {
                Database.Clients.Add(clients);
                Database.SaveChanges();
                using (var Data = new SystemModelContainer())
                {
                    Data.StoreInfo("Se ha agregado el cliente: " + clients.Name + " (" + clients.RNC + ").", DateTime.Now);
                    Data.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            // Audits Saved to the Database
            ViewBag.ElementID = Request.Form["RNC"];

            return View(clients);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clients clients = Database.Clients.Find(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            return View(clients);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RNC,Name,Phone,Email,Category")] Clients clients)
        {
            if (ModelState.IsValid)
            {
                Database.Entry(clients).State = EntityState.Modified;
                Database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clients);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clients clients = Database.Clients.Find(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            return View(clients);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clients clients = Database.Clients.Find(id);
            Database.Clients.Remove(clients);
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
