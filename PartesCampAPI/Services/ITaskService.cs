using PartesCampAPI.Models;
using PartesCampAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Services
{
    public interface ITaskService
    {
        Task<Task> FindByIdAsync(int id);
        Task<TaskResponse> CreateAsync(Tarea task);

        Task<TaskResponse> UpdateAsync(int id, Tarea task);

        Task<TaskResponse> DeleteAsync(int id);
    }
}
