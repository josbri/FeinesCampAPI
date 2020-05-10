using PartesCampAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Services
{
    public interface IUserService
    {
        Task<User> FindByJwtId(string id);
        Task<UserResponse> CreateAsync(User user);

        Task<UserResponse> UpdateAsync(int id, User user);

        Task<UserResponse> DeleteAsync(int id);

    }
}
