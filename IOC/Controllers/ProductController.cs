using IOC.Infrastructure.Repositories.Abstract;
using IOC.Models;
using IOC.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace IOC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Category> _crepo;
        private readonly IRepository<Supplier> _srepo;

        public ProductController(IRepository<Category> crepo, IRepository<Supplier> srepo)
        {
            _crepo = crepo;
            _srepo = srepo;
        }

       [HttpGet]//defaultta httpget olarak kabul eder
       public IActionResult Create()
        {
            //CreateProductVM nesnesi oluşturayım ve on doldurayım.

            var model = new CreateProductVM()
            {
                Categories = _crepo.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.CategoryId.ToString() }).ToList(),
            };
            return View();
        }
    }
}
