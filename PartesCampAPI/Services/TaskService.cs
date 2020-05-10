using PartesCampAPI.Models;
using PartesCampAPI.Repository;
using PartesCampAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TaskService(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Task> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TaskResponse> CreateAsync(Tarea task)
        {
            try
            {
                _taskRepository.Add(task);
                await _unitOfWork.CompleteAsync();

                return new TaskResponse(task);
            }
            catch (Exception ex)
            {
                return new TaskResponse($"There was an errorsaving the task: {ex.Message}");
            }
        }

        public async Task<TaskResponse> DeleteAsync(int id)
        {
            var existingTask = await _taskRepository.FindFirstByConditionAsync(t => t.ID == id);

            if (existingTask == null)
            {
                return new TaskResponse("Task not found");
            }

            try
            {
                _taskRepository.Remove(existingTask);
                await _unitOfWork.CompleteAsync();

                return new TaskResponse(existingTask);
            }

            catch (Exception ex)
            {
                return new TaskResponse($"An error occurred when deleting the task: {ex.Message}");
            }

        }

      
        public async Task<TaskResponse> UpdateAsync(int id, Tarea task)
        {
            var existingTask = await _taskRepository.FindFirstByConditionAsync(t => t.ID == id);

            if (existingTask == null)
            {
                return new TaskResponse("Task not found.");
            }

            existingTask = task;

            try
            {
                _taskRepository.Update(existingTask);
                await _unitOfWork.CompleteAsync();

                return new TaskResponse(existingTask);
            }
            catch (Exception ex)
            {
                return new TaskResponse($"An error occurred when updating the task: {ex.Message}");
            }
        }
    }
}
