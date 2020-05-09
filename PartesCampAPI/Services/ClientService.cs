using PartesCampAPI.Models;
using PartesCampAPI.Repository;
using PartesCampAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClientService (IClientRepository clientRepository, IUnitOfWork unitOfWork)
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ClientResponse> CreateAsync(Client client)
        {
            try
            {
                _clientRepository.Add(client);
                await _unitOfWork.CompleteAsync();

                return new ClientResponse(client);
            }
            catch (Exception ex)
            {
                return new ClientResponse($"There was an errorsaving the client: {ex.Message}");
            }
        }

        public async Task<ClientResponse> UpdateAsync(int id, Client client)
        {
            var existingClient = await _clientRepository.FindByIdAsync(id);

            if(existingClient == null)
            {
                return new ClientResponse("Client not found.");
            }

            existingClient = client;

            try
            {
                _clientRepository.Update(existingClient);
                await _unitOfWork.CompleteAsync();

                return new ClientResponse(existingClient);
            }
            catch(Exception ex)
            {
                return new ClientResponse($"An error occurred when updating the client: {ex.Message}");
            }
        }

        public async Task<ClientResponse> DeleteAsync(int id)
        {
            var existingClient = await _clientRepository.FindByIdAsync(id);

            if(existingClient == null)
            {
                return new ClientResponse("Client not found");
            }

            try
            {
                _clientRepository.Remove(existingClient);
                await _unitOfWork.CompleteAsync();

                return new ClientResponse(existingClient);
            }

            catch (Exception ex)
            {
                return new ClientResponse($"An error occurred when deleting the client: {ex.Message}");
            }
        }
    }
}
