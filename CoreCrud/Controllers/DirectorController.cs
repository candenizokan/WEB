using Microsoft.AspNetCore.Mvc;

namespace CoreCrud.Controllers
{
    public class DirectorController : Controller
    {
       //önce boş bir form verilecek doldurup post edecğiz

        public IActionResult Create()
        {
            return View();
        }


    }
}
