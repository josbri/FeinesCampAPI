using PartesCampAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Repository
{
    public interface ILandRepository
    {
        #region GetLandAsync

        Task<Land> GetLandAsync(int id);
        #endregion

        #region AddClient

        void AddLand(Land landToAdd);
        #endregion

        #region SaveChangesAsync

        Task<bool> SaveChangesAsync();
        #endregion
    }
}
