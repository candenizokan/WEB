using CoreCrud.Infrastructure.Interfaces.Concrete;
using CoreCrud.Models.Concrete;
using CoreCrud.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CoreCrud.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorRepo _aRepo;

        public ActorController(IActorRepo aRepo)
        {
            _aRepo = aRepo;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateActorDTO dto)
        {
            if (ModelState.IsValid)
            {
                Actor actor = new Actor() { FirstName = dto.FirstName, LastName = dto.LastName, BirthDate = dto.BirthDate };

                _aRepo.Create(actor);
                return RedirectToAction("ListOfActor");
            }
            return View(dto);
        }

        public IActionResult ListOfActor() // sahip oldupum tüm aktif aktörleri görüntülemek
        {
            return View(_aRepo.GetDefaults(a => a.IsActive));
        }

        [HttpGet]
        public IActionResult Update(int id) //not => asp-route da hangi ismi verdiysek o ismi burada kullanmalıyız.
        {
            Actor actor = _aRepo.GetDefault(a => a.ID == id);

            UpdateActorDTO dto = new UpdateActorDTO() { ID = actor.ID, FirstName = actor.FirstName, LastName = actor.LastName, BirthDate = actor.BirthDate.Value };

            return View(dto);
        }

        [HttpPost]
        public IActionResult Update(UpdateActorDTO entity)
        {
            if (ModelState.IsValid)
            {
                Actor actor = _aRepo.GetDefault(a => a.ID == entity.ID);
                actor.FirstName = entity.FirstName;
                actor.LastName = entity.LastName;
                actor.BirthDate = entity.BirthDate;

                _aRepo.Update(actor);
                return RedirectToAction("ListOfActor");
            }
            return View(entity);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Actor actor = _aRepo.GetDefault(a => a.ID == id);
            return View(actor);
        }

        [HttpPost]
        public IActionResult Delete(Actor actor)
        {
            Actor deletedActor = _aRepo.GetDefault(a => a.ID == actor.ID);
            _aRepo.Delete(deletedActor);
            return RedirectToAction("ListOfActor");
        }
    }
}
