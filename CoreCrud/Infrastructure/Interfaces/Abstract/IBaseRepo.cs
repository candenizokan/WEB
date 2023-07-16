using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CoreCrud.Infrastructure.Interfaces.Abstract
{
    public interface IBaseRepo<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        T GetDefault(Expression<Func<T,bool>> expression); //tek bir T nesnesini bir expression sonucu döner

        List<T> GetDefaults(Expression<Func<T,bool>> expression); //expressiona uyan tüm T tiğindeki nesneleri getirir.


        //Bir tablo üzerinden expression isimli parametreyke önce eleme yapıp, koşulu sağlayan nesneleri alırız.
        // selector isimli parametre ile tam olarak T tipini değil, bir dto yada vm döndüreceksek elimizdeki T ile diğer tiği işler bir Tresult döndürmüş oluruz.
        // defaultta null bırakılan yani sıralamayan elimizdeki sonuc kümesini istersek orderby isimli parametre ile sıralayabiliriz.


        List<TResult> GetByDefaults<TResult>(Expression<Func<T,TResult>> selector,  //select seçim
                                             Expression<Func<T, TResult>> expression,//filtreleme - where
                                             Func<IQueryable<T>,IOrderedQueryable<T>> orderBy=null //sıralama - order by
                                            );
    }
}
