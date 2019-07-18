using Lab.Data.Context;
using Lab.Domain.Core.Models;
using Lab.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Lab.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity<T>
    {
        protected LabContext _labContext;
        protected DbSet<T> DbSet;
        public Repository(LabContext labContext)
        {
            _labContext = labContext;
            DbSet = _labContext.Set<T>();
        }
        public void Add(T obj)
        {
            DbSet.Add(obj);
        }        
        public T GetById(Guid id)
        {
            return DbSet.Find(id);
        }
        public void Update(T obj)
        {
            DbSet.Update(obj);
        }
        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }       
        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }
        public IEnumerable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }        
        public int SaveChanges()
        {
            return _labContext.SaveChanges();
        }
        public void Dispose()
        {
            _labContext.Dispose();
        }
    }
}
