using CoreCrud.Infrastructure.Interfaces.Abstract;
using CoreCrud.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CoreCrud.Infrastructure.Abstarct
{
    public abstract class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
    {
        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public List<TResult> GetByDefaults<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, TResult>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            throw new NotImplementedException();
        }

        public T GetDefault(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<T> GetDefaults(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
