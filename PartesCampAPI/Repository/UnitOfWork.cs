using PartesCampAPI.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        //Now every repository saves using this, avoiding data inconsistency.
        //EF Core already implements Repository and UoW.
        private readonly PartesCampContext _context;

        public UnitOfWork (PartesCampContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
