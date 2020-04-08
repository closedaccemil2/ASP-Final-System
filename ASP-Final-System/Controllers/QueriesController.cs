using ASP_Final_System.Models;
using ASP_Final_System.ViewModel;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_Final_System.Controllers
{
    public class QueriesController : Controller
    {
        private readonly SystemModelContainer Database = new SystemModelContainer();

        // GET: Queries
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrintAll()
        {
            return new ActionAsPdf("Index");
        }

        public PartialViewResult FilterProduct()
        {
            var Products = from e in Database.Products
                          orderby e.Name ascending
                          select e;
            return PartialView(Products);
        }

        public PartialViewResult ClientName()
        {
            var Clients = from e in Database.Clients
                          orderby e.Name ascending
                          select e;
            return PartialView(Clients);
        }

        public PartialViewResult ClientCategory()
        {
            var Clients = from e in Database.Clients
                          orderby e.Category ascending
                          select e;
            ViewBag.CategoryCount = Clients.Count();
            return PartialView(Clients);
        }

        public PartialViewResult ProviderName()
        {
            var Clients = from e in Database.Providers
                          orderby e.Name ascending
                          select e;
            return PartialView(Clients);
        }

        public PartialViewResult ProviderEmail()
        {
            var Clients = from e in Database.Providers
                          orderby e.Email ascending
                          select e;
            return PartialView(Clients);
        }

        public PartialViewResult EntriesProduct()
        {
            var Entries = from e in Database.Entries
                          orderby e.Product ascending
                          select e;
            ViewBag.pdCount = Entries.Count();
            ViewBag.pdSum = Entries.Sum(e => e.Product.Length);
            ViewBag.pdAvg = Entries.Average(e => e.Product.Length);
            return PartialView(Entries);
        }

        public PartialViewResult EntriesDate()
        {
            var Entries = from e in Database.Entries
                          orderby e.TimeStamp ascending
                          select e;
            ViewBag.dCount = Entries.Count();
            ViewBag.dSum = Entries.Sum(e => e.TimeStamp.Length);
            ViewBag.dAvg = Entries.Average(e => e.TimeStamp.Length);
            return PartialView(Entries);
        }

        public PartialViewResult EntriesProvider()
        {
            var Entries = from e in Database.Entries
                          orderby e.Provider ascending
                          select e;
            ViewBag.pvCount = Entries.Count();
            ViewBag.pvSum = Entries.Sum(e => e.Provider.Length);
            ViewBag.pvAvg = Entries.Average(e => e.Provider.Length);
            return PartialView(Entries);
        }

        public PartialViewResult BillingDate()
        {
            var Billing = from e in Database.Billings
                          orderby e.SaleDate ascending
                          select e;
            ViewBag.bdCount = Billing.Count();
            ViewBag.bdSum = Billing.Sum(e => e.SaleDate.ToString().Length);
            ViewBag.bdAvg = Billing.Average(e => e.SaleDate.ToString().Length);
            ViewBag.bdMin = Billing.Min(e => e.SaleDate.Value);
            ViewBag.bdMax = Billing.Max(e => e.SaleDate.Value);
            return PartialView(Billing);
        }

        public PartialViewResult BillingClient()
        {
            var Billing = from e in Database.Billings
                          orderby e.ClientName ascending
                          select e;
            ViewBag.bcCount = Billing.Count();
            ViewBag.bcSum = Billing.Sum(e => e.ClientName.Length);
            ViewBag.bcAvg = Billing.Average(e => e.ClientName.Length);
            ViewBag.bcMin = Billing.Min(e => e.ClientName.Length);
            ViewBag.bcMax = Billing.Max(e => e.ClientName.Length);
            return PartialView(Billing);
        }
    }
}