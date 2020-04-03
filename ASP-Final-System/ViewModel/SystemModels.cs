﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_Final_System.Models;

namespace ASP_Final_System.ViewModel
{
    public class SystemModels
    {
        public IEnumerable<Audit> Audits { get; set; }
        public IEnumerable<Products> Products { get; set; }
        public IEnumerable<Providers> Providers { get; set; }
        public IEnumerable<Clients> Clients { get; set; }
    }
}