using Microsoft.AspNetCore.Mvc;
using StreetCountryWebApp.Models;
using StreetCountryWebApp.Services;

namespace StreetCountryWebApp.Controllers
{
    public class StreetsController : Controller
    {
        public IStreetService service;
        public StreetsController(IStreetService service)
        {
            this.service = service;
        }

        public IActionResult Search(string pattern) //
        {
            var streets = service.Read(pattern);
            return View(streets);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var street = service.Read(id);
                return View(street);
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(Street street)
        {
            service.Update(street);
            return RedirectToAction(nameof(Search));
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                var street = service.Read(id);
                return View(street);
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return RedirectToAction(nameof(Search));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Street street)
        {
            service.Create(street);
            return RedirectToAction(nameof(Search));
        }
    }
}
