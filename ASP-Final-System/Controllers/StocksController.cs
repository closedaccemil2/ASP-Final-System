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
    public class StocksController : Controller
    {
        private readonly SystemModelContainer Database = new SystemModelContainer();

        // GET: Stocks
        public ActionResult Index()
        {
            var Data = new SystemModels
            {
                Stocks = Database.Stocks.ToList(),
                Products = Database.Products.ToList(),
                Providers = Database.Providers.ToList(),
                Billing = Database.Billings.ToList(),
                Audits = Database.Audits.ToList()
            };
            ViewBag.prods = new SelectList(Database.Products, "Name", "Name");
            ViewBag.provs = new SelectList(Database.Providers, "Name", "Name");
            return View(Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Stock stock)
        {
            if (ModelState.IsValid)
            {
                using (var Data = new SystemModelContainer())
                {
                    Data.StockCheck(stock.Quantity, stock.Product, stock.Provider, DateTime.Now);
                    Data.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }


        // GET: Stocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = Database.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Quantity,Product,Provider,TimeStamp")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                Database.Entry(stock).State = EntityState.Modified;
                Database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stock);
        }

        // GET: Stocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = Database.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stock stock = Database.Stocks.Find(id);
            Database.Stocks.Remove(stock);
            Database.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Billing()
        {
            var Data = new SystemModels
            {
                Billing = Database.Billings.ToList(),
                Clients = Database.Clients.ToList(),
                Products = Database.Products.ToList(),
            };
            ViewBag.custs = new SelectList(Database.Clients, "Category", "Name");
            ViewBag.prods = new SelectList(Database.Products, "Price", "Name");
            return View(Data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Billing(Billing billing, string ClientName, string ProductName)
        {
            if (ModelState.IsValid)
            {
                using (var Data = new SystemModelContainer())
                {
                    Data.CreateBill(ClientName, ProductName, billing.Quantity, billing.TotalPrice, DateTime.Now);
                    Data.SaveChanges();
                }
            }
            return RedirectToAction("Billing");
        }

        public ActionResult Entries()
        {
            var Data = new SystemModels
            {
                Entries = Database.Entries1.ToList(),
            };
            return View(Data);
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
