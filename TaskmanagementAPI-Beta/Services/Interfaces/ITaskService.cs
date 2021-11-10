using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskmanagementAPI_Beta.Models.Dtos;

namespace TaskmanagementAPI_Beta.Domain
{
    public interface ITaskService
    {
        public Task<IEnumerable<TaskReadDto>> GetAllTasks();
        public Task<Boolean> ChangeStatus(int TaskId, int StatusId);
        Task CreateTaskAsync(TaskCreateDto taskCreateDto);
        Task<bool> DeleteTaskAsync(int id);
        Task<TaskReadDto> GetTaskByIdAsync(int id);
        Task<bool> UpdateTaskByIdAsync(int id, TaskCreateDto taskCreateDto);
    }
}
