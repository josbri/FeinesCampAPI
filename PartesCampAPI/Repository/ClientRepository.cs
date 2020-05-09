using Microsoft.EntityFrameworkCore;
using PartesCampAPI.data;
using PartesCampAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Repository
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        #region Constructor

        public ClientRepository(PartesCampContext context) : base(context) { }
        #endregion

        /// <summary>
        /// Includes Land
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        #region GetByConditionAsync
        public async Task<Client> FindByIdAsync(int id)
        {

            return   await _context.Clients.Include(c => c.Land).AsNoTracking().FirstOrDefaultAsync(c => c.ID == id);
        }
        #endregion

       

    }
}
