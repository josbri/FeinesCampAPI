using PartesCampAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Repository
{
    public interface IClientRepository
    {
        #region GetClientAsync

        Task<Client> GetClientAsync(int id);
        #endregion

        #region AddClient

        void AddClient(Client clientToAdd);
        #endregion

        #region SaveChangesAsync

        Task<bool> SaveChangesAsync();
        #endregion
    }
}
