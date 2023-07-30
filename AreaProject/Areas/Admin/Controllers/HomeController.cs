using Microsoft.AspNetCore.Mvc;

namespace AreaProject.Areas.Admin.Controllers
{

    //şu an hangi areada olduğunu yazman lazım. yoksa route'da görmez. sen burada garanti veeriyorsun. sen bir areasın diyorsun.

    [Area("Admin")]
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
