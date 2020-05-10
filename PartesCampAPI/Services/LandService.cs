using PartesCampAPI.Models;
using PartesCampAPI.Repository;
using PartesCampAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Services
{
    public class LandService : ILandService
    {
        private readonly ILandRepository _landRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LandService(ILandRepository landRepository, IUnitOfWork unitOfWork)
        {
            _landRepository = landRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<LandResponse> CreateAsync(Land land)
        {
            try
            {
                _landRepository.Add(land);
                await _unitOfWork.CompleteAsync();

                return new LandResponse(land);
            }
            catch (Exception ex)
            {
                return new LandResponse($"There was an error saving the land: {ex.Message}");
            }
        }

        public async Task<LandResponse> DeleteAsync(int id)
        {
            var existingLand = await _landRepository.FindFirstByConditionAsync(l => l.ID == id);

            if (existingLand == null)
            {
                return new LandResponse("Land not found");
            }

            try
            {
                _landRepository.Remove(existingLand);
                await _unitOfWork.CompleteAsync();

                return new LandResponse(existingLand);
            }

            catch (Exception ex)
            {
                return new LandResponse($"An error occurred when deleting the land: {ex.Message}");
            }
        }

        public async Task<LandResponse> UpdateAsync(int id, Land land)
        {
            var existingLand = await _landRepository.FindFirstByConditionAsync(l => l.ID == id);

            if (existingLand == null)
            {
                return new LandResponse("Land not found.");
            }

            existingLand = land;

            try
            {
                _landRepository.Update(existingLand);
                await _unitOfWork.CompleteAsync();

                return new LandResponse(existingLand);
            }
            catch (Exception ex)
            {
                return new LandResponse($"An error occurred when updating the land: {ex.Message}");
            }
        }
    }
}
