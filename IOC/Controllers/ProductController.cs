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
        private readonly IRepository<Product> _prepo;

        public ProductController(IRepository<Category> crepo, IRepository<Supplier> srepo, IRepository<Product> prepo)
        {
            _crepo = crepo;
            _srepo = srepo;
            _prepo = prepo;
        }

        [HttpGet]//defaultta httpget olarak kabul eder
        public IActionResult Create()
        {
            //CreateProductVM nesnesi oluşturayım ve on doldurayım.

            var model = new CreateProductVM()
            {
                Categories = _crepo.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.CategoryId.ToString() }).ToList(),
                Suppliers = _srepo.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.SupplierId.ToString() }).ToList(),
                Product = new Product()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            return View();
        }

    }
}
