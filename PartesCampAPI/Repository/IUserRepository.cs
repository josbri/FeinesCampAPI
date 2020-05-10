using PartesCampAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {

        public Task<User> FindByJwtAsync(string id);
    }
}
