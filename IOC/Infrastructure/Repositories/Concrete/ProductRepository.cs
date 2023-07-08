using IOC.Infrastructure.Repositories.Abstract;
using IOC.Models;
using IOC.Models.Context;
using System.Collections.Generic;

namespace IOC.Infrastructure.Repositories.Concrete
{
    public class ProductRepository : IRepository<Product>
    {
        //ihtiyacı newleyerek yapmamalısın ProjectContext new 
        
        public void Add(Product entity)
        {
            //projetcontest sınıfı üzerinden ekle demem lazım
        }

        public IList<Product> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public int Save()
        {
            throw new System.NotImplementedException();
        }
    }
}
