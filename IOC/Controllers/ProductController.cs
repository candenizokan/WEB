using IOC.Models.VMs;
using Microsoft.AspNetCore.Mvc;

namespace IOC.Controllers
{
    public class ProductController : Controller
    {

        public ProductController()
        {

        }

       [HttpGet]//defaultta httpget olarak kabul eder
       public IActionResult Create()
        {
            //CreateProductVM nesnesi oluşturayım ve on doldurayım.

            var model = new CreateProductVM()
            {
                
            };
            return View();
        }
    }
}
