using IOC.Infrastructure.Repositories.Abstract;
using IOC.Models;
using System.Collections.Generic;

namespace IOC.Infrastructure.Repositories.Concrete
{
    public class CategoryRepository : IRepository<Category>
    {


        public void Add(Category entity)
        {
            throw new System.NotImplementedException();
        }

        public IList<Category> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public int Save()
        {
            throw new System.NotImplementedException();
        }
    }
}
