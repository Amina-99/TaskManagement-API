using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskmanagementAPI_Beta.Models;
using TaskmanagementAPI_Beta.Models.Dtos;

namespace TaskmanagementAPI_Beta.Data
{
    public interface ITaskRepository
    {
        System.Threading.Tasks.Task<bool> CreateTaskAsync(Models.Task task);
        Task<bool> DeleteTaskAsync(int id);
        Task<Models.Task> GetTaskByIdAsync(int id);
        Task<bool> UpdateTaskByIdAsync(int id, Models.Task task);
        public Task<IEnumerable<Models.Task>> GetAllTasks();
        public Task<Boolean> ChangeStatus(int TaskId, int StatusId);    
    }
}
