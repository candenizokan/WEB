using CoreCrud.Infrastructure.Interfaces.Concrete;
using CoreCrud.Views.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreCrud.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepo _mrepo;
        private readonly IDirector _dRepo;

        //bir sınıf başkka bir sınıfa ihtiyaç duyuyorsa sınıfın ctorunda enjeksiyonla kullanmam lazım. ben senin soyut halin olan interface IMovieRepo tipinden birşey istiyorum. sen bana movie reponun sınıf halini vermen lazım. interface neyi nasıl yapacağını bilmez. bunun kodunu unutmadan startupta söylemem lazım. ben bunun soyut halini istediğimde bana somut halini ver demem lazım bunu startupda söylüyorum
        public MovieController(IMovieRepo mrepo, IDirector dRepo)
        {
            _mrepo = mrepo;
            _dRepo = dRepo;
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

               
            };
            return View();
        }

    }
}
