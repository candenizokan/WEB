using CoreCrud.Infrastructure.Interfaces.Concrete;
using CoreCrud.Models.Concrete;
using CoreCrud.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CoreCrud.Controllers
{
    public class DirectorController : Controller
    {
        private readonly IDirector _dRepo;

        public DirectorController(IDirector dRepo)//IDirectorRepo
        {
            _dRepo = dRepo;
        }

       //önce boş bir form verilecek doldurup post edecğiz

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDirectorDTO dto)
        {
            if (ModelState.IsValid)
            {
                Director director = new Director() { FirstName =dto.FirstName, LastName =dto.LastName,BirthDate =dto.BirthDate };

                _dRepo.Create(director);
                return RedirectToAction("List");
            }
            return View(dto);
        }

    }
}
