using Microsoft.EntityFrameworkCore;
using PartesCampAPI.data;
using PartesCampAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Repository
{
    public class ClientRepository : IClientRepository
    {
        #region Constructor
        private readonly PartesCampContext _context;

        public ClientRepository (PartesCampContext context)
        {
            _context = context ?? throw new ArgumentNullException( nameof(context));
        }

        #endregion


        #region GetBookAsync
        public async Task<Client> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException( nameof(id));
            }

            return   await _context.Clients.Include(c => c.Land).FirstOrDefaultAsync(c => c.ID == id);
        }
        #endregion

        #region AddClient

        //Not worth it to write async it.
        public void Create(Client clientToAdd)
        {
            if (clientToAdd == null)
            {
                throw new ArgumentException(nameof(clientToAdd));
            }
           
            try
            {

                _context.Add(clientToAdd);
            }
            catch
            {
                throw;
            }
        }
        #endregion


        #region Delete
        public void Delete(Client clientToDelete)
        {
            if (clientToDelete == null)
            {
                throw new ArgumentException(nameof(clientToDelete));
            }

            try
            {
                _context.Remove(clientToDelete);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        public void Update(Client clientToUpdate)
        {
            if (clientToUpdate == null)
            {
                throw new ArgumentException(nameof(clientToUpdate));
            }
            try
            {
                _context.Update(clientToUpdate);

            }
            catch
            {
                throw;
            }
        }
        #region SaveChanges
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        #endregion

    }
}
