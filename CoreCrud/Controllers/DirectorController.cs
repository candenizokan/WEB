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
                return RedirectToAction("ListOfDirector");
            }
            return View(dto);
        }


        public IActionResult ListOfDirector() // sahip oldupum tüm aktif yönetmenleri görüntülemek
        {
            return View(_dRepo.GetDefaults(a=> a.IsActive));
        }

        [HttpGet]
        public IActionResult Update(int id) //not => asp-route da hangi ismi verdiysek o ismi burada kullanmalıyız.
        {
            Director director = _dRepo.GetDefault(a => a.ID == id);

            UpdateDirectorDTO dto = new UpdateDirectorDTO() { ID=director.ID, FirstName=director.FirstName, LastName=director.LastName, BirthDate= director.BirthDate.Value};

            return View(dto);
        }

        [HttpPost]
        public IActionResult Update(UpdateDirectorDTO entity)
        {
            if (ModelState.IsValid)
            {
                Director director = _dRepo.GetDefault(a => a.ID == entity.ID);
                director.FirstName = entity.FirstName;
                director.LastName = entity.LastName;
                director.BirthDate = entity.BirthDate;

                _dRepo.Update(director);
                return RedirectToAction("ListOfDirector");
            }
            return View(entity);
        }

    }
}
