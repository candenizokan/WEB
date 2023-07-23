using CoreCrud.Infrastructure.Interfaces.Concrete;
using CoreCrud.Models.Concrete;
using CoreCrud.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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


        /*
         
         **VIEWBAG - VIEWDATA - TEMPDATA
         *
         *ViewBag, ViewData, TempData => data transfer to view yapılardır. Yani viewlara veri taşımak için kullandığımız yapılardır. List, string, datetime vb. yapıları taşıyabilirler.
         *
         *ViewBag => ViewData ile aynı çalışma mantığına sahiptir. Abstract controllerBase tarafından oluşmuşlardır. DYNAMIC tipte GET metoduna sahiptir
         *
         *ViewData => ViewDictionary (sözlük, yani anahtar değer eşleşmesi şeklinde çalışır.) tipinde oluşmuş GET ve SET metoduna sahiptir.
         *
         *ViewData, viewBag den daha hızlıdır ve sürüm olarak MVC 1.0 dan ileri sürümlerde vardır
         *
         *ViewBag ise MVC 3ç0 dan ve ileri sürümlerde vardır.
         *
         *VIEWBAG ile VİEWDATA oluştuğunu actionun viewlarında kullanılır ancak başka bir actionun viewında çalışmaz, taşınamaz. Action tetiklenip bu yapılar her yeniden oluştuğunda tek seferlik kullanılabilir hale gelirler ancak ilgili action scope (süslü parantez) dışında yaşayamazlar.
         *
         *TempData => Diğerleri ile benzer mantıktadır ANCAK diğerlerinden en büyük farkı oluştuktan sonra oluştuğu actionun dışında tek seferliğine mahsus çalışabilir acak başka actionda kullanılduğunda aynı zamanda kendi actionunda kullanılamaz. Başka actionun viewında kullanılırsa o sayfa yenilendiğinde tempdata kaybolur çünkü yenilenemez. Bu anlamda sonuç olarak oluştuğu actionun viewında her yenilendiğinde kullanabileceğini ancak kendi viewında kullanılmazsa başka viewda 1 kereliğine kullanabileceğini söyleyebiliriz.
         
         */

        public IActionResult CreateDataTransferToView()
        {
            TempData["weekList"] = new List<string> { "Pazartesi", "Salı", "Çarşamba" };
            ViewBag.weekList2 = new List<string> { "Perşembe", "Cuma" };
            ViewData["weekList3"] = new List<string> { "Cumartesi", "Pazar" };

            TempData["Bugün"] = DateTime.Now;
            
            return View();
        }
    }
}
