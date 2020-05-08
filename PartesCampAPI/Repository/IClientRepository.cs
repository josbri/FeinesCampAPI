using PartesCampAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Repository
{
    public interface IClientRepository
    {
        //#region GetAllAsync
        //Task<Client> GetAll();
        //#endregion

        #region GetByIdAsync
        Task<Client> GetByIdAsync(int id);
        #endregion

        #region Create

        void Create(Client clientToAdd);
        #endregion

        #region Delete
        void Delete(Client clientToAdd);
        #endregion

        #region Update
        void Update(Client clientToAdd);
        #endregion

        #region SaveChangesAsync
        Task<bool> SaveChangesAsync();
        #endregion
    }
}
