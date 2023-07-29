using CoreCrud.Infrastructure.Interfaces.Concrete;
using CoreCrud.Models.Concrete;
using CoreCrud.Models.DTOs;
using CoreCrud.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace CoreCrud.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepo _mrepo;
        private readonly IDirector _dRepo;
        private readonly IActorRepo _aRepo;

        //bir sınıf başkka bir sınıfa ihtiyaç duyuyorsa sınıfın ctorunda enjeksiyonla kullanmam lazım. ben senin soyut halin olan interface IMovieRepo tipinden birşey istiyorum. sen bana movie reponun sınıf halini vermen lazım. interface neyi nasıl yapacağını bilmez. bunun kodunu unutmadan startupta söylemem lazım. ben bunun soyut halini istediğimde bana somut halini ver demem lazım bunu startupda söylüyorum
        public MovieController(IMovieRepo mrepo, IDirector dRepo, IActorRepo aRepo)
        {
            _mrepo = mrepo;
            _dRepo = dRepo;
            _aRepo = aRepo;
        }


        public IActionResult MakeFilm()
        {

            // elinde olan tüm aktörleri yönetmenleri öncce göstermem lazım. çünkü belki veritabanında ekleyeceğim yok.  tek bir sınıfın verisini taşımıyorsa başka sınıftanda veriler gelecekse VM yapmam lazım. dto bir sınıfın traşlanması gibi düşünebilirsin

            //CreateMovieVM nesnesi oluşturmam lazım.

            CreateMovieVM vm = new CreateMovieVM()
            {
                Directors = _dRepo.GetByDefaults
                (
                    selector:a =>new SelectListItem() { Text =a.FullName, Value = a.ID.ToString()},
                    expression:a => a.IsActive
                ),// director repoya ihtiyacım oldu. o zaman ctorda director repoyu çağıracağım. GetByDefaults IBASEREPODA vardı. seçim parametrem var hangi property alıyorsun, koşulunu yaz parametren expression, sıralama yapabileceğin parametren var. güncelde aktif olan kullanıcıları where yazacağım.

               //sahip olduğum tüm aktörleri getirmem lazım. aktör repoya ihtiyacım oldu.

                Actors = _aRepo.GetByDefaults
                (
                    selector:a=> new ActorDTO() { ActorID=a.ID, FullName=a.FullName,IsSelected=false },
                    expression: a=> a.IsActive
                )
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult MakeFilm(CreateMovieVM vm)
        {
            if (ModelState.IsValid)
            {
                Movie movie = new Movie()
                {
                    Name = vm.Name,
                    PublishDate = vm.PublishDate,
                    DirectorId= vm.DirectorID,
                    Director =_dRepo.GetDefault(a=>a.ID==vm.DirectorID)
                };

                foreach (var item in vm.Actors.Where(a=>a.IsSelected))//seçili actorDtolar dönülecek
                {
                    MovieActor movieActor = new MovieActor()//önce ara tablo elemanlarını oluşturdun
                    {
                        ActorId = item.ActorID,
                        Actor = _aRepo.GetDefault(a => a.ID == item.ActorID),
                        Movie = movie
                    };
                    movie.MovieActors.Add(movieActor);//movie ekledin
                }

                _mrepo.Create(movie);
                return RedirectToAction("List");
            }

            //negatif senaryoda geri döndürmeden önce tekrardan doldurmam lazım

            vm.Directors = _dRepo.GetByDefaults
                (
                    selector: a => new SelectListItem() { Text = a.FullName, Value = a.ID.ToString() },
                    expression: a => a.IsActive
                );
            vm.Actors = _aRepo.GetByDefaults
                (
                    selector: a => new ActorDTO() { ActorID = a.ID, FullName = a.FullName, IsSelected = false },
                    expression: a => a.IsActive
                );
            return View(vm);
        }

        public IActionResult List()
        {
            return View(_mrepo.GetDefaults(a=>a.IsActive));
        }

        public IActionResult Edit( int id)
        {
            //kimi güncelleyeceğim bulmam lazım

            Movie movie = _mrepo.GetDefault(a=> a.ID == id);//güncellenecek film

            UpdateMovieVM vm = new UpdateMovieVM()
            {
                MovieID = movie.ID,
                Name = movie.Name,
                PublishDate = movie.PublishDate,
                DirectorID = movie.DirectorId,
                Directors = _dRepo.GetByDefaults
                (selector: a => new SelectListItem() { Text = a.FullName, Value = a.ID.ToString() },
                    expression: a => a.IsActive)//sahip olduğum tüm direktörleride göndereceğim
            };

            //tüm aktif aktörlemi dön diyorum
            foreach (var item in _aRepo.GetDefaults(a=>a.IsActive))
            {
                //yeni bir actorDto nesnesi ekliyorsun. vm üzerine aktif her oyuncuyu seçilmemiş olarak ekledim
                vm.Actors.Add(new ActorDTO() { ActorID = item.ID, FullName = item.FullName, IsSelected = false });//elinde sepet yokken eklemeye çalışıyorsan hata alırsın. ya buraya gelmeden hemen önce newleyip ayağa kaldırman lazım. yada ilk oluşturduğun yerde yapman lazım.updatemovievm de ctorda newle oluştur.

                foreach (var actor in movie.MovieActors)//filmin üzerindeki seçili movieActor nesnelerini dönüyoruz
                {
                    if (actor.ActorId == item.ID)//bu aktör zaten seçilmiştir onun isSelectedını false değil true yapalım
                    {
                        vm.Actors.Find(a => a.ActorID == actor.ActorId).IsSelected = true;
                    }//seçilmemişlerle seçilmişleri kıyaslayıp seçilmişlerin is selectedını true yapıyorum
                }
            }


            return View(vm);
        }

    }
}
