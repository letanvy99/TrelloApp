using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Trello.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entity);
        void Delete(T entity);
        void Update(T entity);
        Task<T> FindAsync(params object[] keyValues);
        IQueryable<T> List(Expression<Func<T, bool>> expression);
    }
}
