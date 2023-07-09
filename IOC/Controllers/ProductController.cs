using IOC.Infrastructure.Repositories.Abstract;
using IOC.Models;
using IOC.Models.VMs;
using Microsoft.AspNetCore.Mvc;

namespace IOC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Category> _crepo;

        public ProductController(IRepository<Category> crepo)
        {
            _crepo = crepo;
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
