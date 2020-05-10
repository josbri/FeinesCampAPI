using Microsoft.EntityFrameworkCore;
using PartesCampAPI.data;
using PartesCampAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(PartesCampContext context) : base(context) { }


        public async Task<User> FindByJwtAsync(string id)
        {

            return await _context.Users.Include(u => u.Clients).ThenInclude(c => c.Land).Include(u => u.Tasks).AsNoTracking().FirstOrDefaultAsync(c => c.UserID == id);
        }

    }
}
