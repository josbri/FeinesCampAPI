using PartesCampAPI.Models;
using PartesCampAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Services
{
    public interface IClientService
    {
        //Task<IEnumerable<Client>> ListAsync();

        Task<ClientResponse> CreateAsync(Client client);

        Task<ClientResponse> UpdateAsync(int id, Client client);

        Task<ClientResponse> DeleteAsync(int id);
    }
}
