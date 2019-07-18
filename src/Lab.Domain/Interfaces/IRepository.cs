using Lab.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Lab.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Entity<T>
    {
        void Add(T obj);
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Update(T obj);
        void Remove(Guid id);
        IEnumerable<T> Search(Expression<Func<T, bool>> predicate);
        int SaveChanges();
    }
}
