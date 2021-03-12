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

        public IActionResult Show(string search)
        {
            var streets = service.Read(search);
            return View(streets);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                Street street = service.Read(id);
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
            return RedirectToAction("Show");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                Street street = service.Read(id);
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
            return RedirectToAction("Show");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Street street)
        {
            service.Create(street);
            return RedirectToAction("Show");
        }
    }
}
