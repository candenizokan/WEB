using CoreCrud.Infrastructure.Interfaces.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreCrud.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepo _mrepo;

        //bir sınıf başkka bir sınıfa ihtiyaç duyuyorsa sınıfın ctorunda enjeksiyonla kullanmam lazım. ben senin soyut halin olan interface IMovieRepo tipinden birşey istiyorum
        public MovieController(IMovieRepo mrepo)
        {
            _mrepo = mrepo;
        }




    }
}
