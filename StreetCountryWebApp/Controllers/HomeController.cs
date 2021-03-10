using Microsoft.AspNetCore.Mvc;
using StreetCountryWebApp.Models;
using System.Linq;

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

        [HttpPost]
        public IActionResult Edit(int id)
        {
            throw new System.NotImplementedException();
        }
        [HttpPut]
        public string Edit()
        {
            throw new System.NotImplementedException();
        }
        [HttpDelete]        
        public IActionResult Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
