using Microsoft.EntityFrameworkCore;
using PartesCampAPI.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PartesCampAPI.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        #region Constructor
        protected  PartesCampContext _context;

        public RepositoryBase(PartesCampContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        #endregion
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T,bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }


        public void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Set<T>().Update(entity);
        }
    



    }
}
