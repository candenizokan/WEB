using System.Collections.Generic;

namespace IOC.Infrastructure.Repositories.Abstract
{
    //generic type kullanmış oldum. T sınıfı şu an bu interface içinde belli değil ama implemente edileceği yerde hangi sınıf seçilirse o sınıf için aşağıdaki metodlar şekillendirilebilir olmuş olacak
    //generic type sınıf, interface, koleksiyon yapıları vb kullanabilir
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        int Save();

        IList<T> GetAll();
    }
}
