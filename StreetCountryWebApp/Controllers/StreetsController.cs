using Microsoft.AspNetCore.Mvc;
using StreetCountryWebApp.Models;
using StreetCountryWebApp.Repo;

namespace StreetCountryWebApp.Controllers
{
    public class StreetsController : Controller
    {
        public IStreetRepository repository;
        public StreetsController(IStreetRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Show(string search)
        {
            if(string.IsNullOrEmpty(search))
            return View(repository.GetAll());

            else 
                return View(repository.GetByString(search));
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
            return RedirectToAction("Show");
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
            repository.Delete(id);
            return RedirectToAction("Show");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Street street)
        {
            repository.Add(street);
            return RedirectToAction("Show");
        }
    }
}
