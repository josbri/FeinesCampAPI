using PartesCampAPI.Models;
using PartesCampAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Services
{
    public interface ILandService
    {
        Task<LandResponse> CreateAsync(Land land);

        Task<LandResponse> UpdateAsync(int id, Land land);

        Task<LandResponse> DeleteAsync(int id);
    }
}
