using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Interfaces
{
    public interface IRepository<TEntity, TId> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(TId id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TId id);
        int SaveChanges();
    }
}
