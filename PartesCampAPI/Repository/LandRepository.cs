using Microsoft.EntityFrameworkCore;
using PartesCampAPI.data;
using PartesCampAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Repository
{
    public class LandRepository
    {
        #region Constructor
        private readonly PartesCampContext _context;

        public LandRepository(PartesCampContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion

        #region GetLandAsync

        public async Task<Land> GetLandAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _context.Lands.Include(c => c.Tasks).FirstOrDefaultAsync(c => c.ID == id);
        }
        #endregion

        #region AddClient

        public void AddLand(Land landToAdd)
        {
            if (landToAdd == null)
            {
                throw new ArgumentException(nameof(landToAdd));
            }

            try
            {

                _context.Add(landToAdd);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region SaveChangesAsync

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
        #endregion

    }
}
