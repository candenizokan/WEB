using CoreCrud.Infrastructure.Interfaces.Concrete;
using CoreCrud.Models.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CoreCrud.Views.Shared.Components.MovieWithDirectorTop
{
    public class MovieWithDirectorTopViewComponent : ViewComponent
    {
        private readonly IDirector _dRepo;

        public MovieWithDirectorTopViewComponent(IDirector dRepo)
        {
            _dRepo = dRepo;
        }
        //en çok filmi olan 3 yönetmeni alalım.
        public IViewComponentResult Invoke()
        {
            List<Director> list = _dRepo.GetDefaults(a=>a.IsActive).OrderByDescending(a=>a.Movies.Where(a=>a.IsActive).Count()).Take(3).ToList();

            return View(list);
        }
    }
}
