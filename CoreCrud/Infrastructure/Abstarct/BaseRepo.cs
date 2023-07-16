using CoreCrud.Infrastructure.Interfaces.Abstract;
using CoreCrud.Models.Abstract;
using CoreCrud.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CoreCrud.Infrastructure.Abstarct
{
    public abstract class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
    {
        //bir sınıfın içinde başka bir sınıfa ihtiyacın varsa ctorda enjekte edeceğim
       
        private readonly ProjectContext _context;
        private readonly DbSet<T> _table;

        public BaseRepo(ProjectContext context)
        {
            _context = context;
            _table = _context.Set<T>();// contextin üzerindeki tabloyu _table a atıyorum
        }
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
