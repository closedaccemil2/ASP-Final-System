using ASP_Final_System.Models;
using ASP_Final_System.ViewModel;
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
    }
}