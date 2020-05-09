using Microsoft.EntityFrameworkCore;
using PartesCampAPI.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PartesCampAPI.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        #region Constructor
        protected  readonly PartesCampContext _context;

        public RepositoryBase(PartesCampContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        #endregion
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T,bool>> expression)
        {
            return await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }


        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

    }
}
