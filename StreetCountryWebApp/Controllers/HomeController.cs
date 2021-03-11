using Microsoft.AspNetCore.Mvc;
using StreetCountryWebApp.Models;
using StreetCountryWebApp.Repo;
using System.Linq;

namespace StreetCountryWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IStreetRepository repository;
        public HomeController(IStreetRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View(repository.GetAll());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                Street street = repository.Find(id);
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
            repository.Update(street);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                Street street = repository.Find(id);
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
            try
            {
                repository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
