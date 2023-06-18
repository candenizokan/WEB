using Microsoft.AspNetCore.Mvc;

namespace Web_Route.Controllers
{
    public class KategoriController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Kontrol()
        {
            return View();
        }
    }
}
