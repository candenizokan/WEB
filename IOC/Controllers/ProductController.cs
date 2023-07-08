using Microsoft.AspNetCore.Mvc;

namespace IOC.Controllers
{
    public class ProductController : Controller
    {
       [HttpGet]//defaultta httpget olarak kabul eder
       public IActionResult Create()
        {
            return View();
        }
    }
}
