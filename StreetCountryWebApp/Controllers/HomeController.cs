using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StreetCountryWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StreetCountryWebApp.Controllers
{
    public class HomeController : Controller
    {
        public DBContext context;
        public HomeController(DBContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.Streets.ToList());
        }
    }
}
