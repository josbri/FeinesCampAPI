﻿using PartesCampAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Repository
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        //Override to include Land.
        public Task<Client> FindByIdAsync(int id);
    }
}
