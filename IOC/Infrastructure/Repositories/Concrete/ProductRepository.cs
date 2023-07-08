using IOC.Infrastructure.Repositories.Abstract;
using IOC.Models;
using IOC.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IOC.Infrastructure.Repositories.Concrete
{
    public class ProductRepository : IRepository<Product>
    {
        //ihtiyacı newleyerek yapmamalısın ProjectContext new 

        private readonly ProjectContext _context;

        public ProductRepository(ProjectContext context)
        {
            _context = context;// dışarıdan gelen contexti buradaki sınıfta kullan
        }
        public void Add(Product entity)
        {
            //projetcontest sınıfı üzerinden ekle demem lazım

            _context.Products.Add(entity);
        }

        public IList<Product> GetAll()
        {
            return _context.Products.Include(a => a.Category).Include(a => a.Supplier).ToList();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
