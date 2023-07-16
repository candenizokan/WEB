﻿using CoreCrud.Infrastructure.Interfaces.Abstract;
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
            _table.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            entity.IsActive = false;
            //_table.Remove(entity); doğrudan virtabanından siler.
            _context.SaveChanges();
        }

        public List<TResult> GetByDefaults<TResult>
            (Expression<Func<T, TResult>> selector, 
            Expression<Func<T, bool>> expression, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _table;

            if (orderBy != null) return orderBy(query).Where(expression).Select(selector).ToList();

            return query.Where(expression).Select(selector).ToList();
            
        }

        public T GetDefault(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression).FirstOrDefault();
        }

        public List<T> GetDefaults(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression).ToList();
        }

        public void Update(T entity)
        {
            _table.Update(entity);
            _context.SaveChanges();
        }
    }
}
