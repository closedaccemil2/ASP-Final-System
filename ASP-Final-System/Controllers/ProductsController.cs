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
    public class ProductsController : Controller
    {
        private readonly SystemModelContainer Database = new SystemModelContainer();

        // GET: Products
        public ActionResult Index()
        {
            var Data = new SystemModels
            {
                Products = Database.Products.ToList(),
                Audits = Database.Audits.ToList()
            };
            return View(Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,Name,Price")] Products products)
        {
            if (ModelState.IsValid)
            {
                Database.Products.Add(products);
                Database.SaveChanges();
                using (var Data = new SystemModelContainer())
                {
                    Data.AuditLog("Se ha agregado el producto: " + products.Name + " (#" + products.Id + ").", DateTime.Now);
                    Data.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = Database.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            // Audits Saved to the Database
            ViewBag.Element_ID = id;

            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price")] Products products)
        {
            if (ModelState.IsValid)
            {
                Database.Entry(products).State = EntityState.Modified;
                Database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = Database.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int id)
        {
            Products products = Database.Products.Find(id);
            Database.Products.Remove(products);
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
