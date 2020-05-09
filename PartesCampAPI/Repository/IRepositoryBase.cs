using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PartesCampAPI.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
       // Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindFirstByConditionAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> FindListByConditionAsync(Expression<Func<T, bool>> expression);

        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);




    }
}
