using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskmanagementAPI_Beta.Models.Dtos;

namespace TaskmanagementAPI_Beta.Data
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskmanagementDbContext _context;

        public TaskRepository(TaskmanagementDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Task> GetTaskByIdAsync(int id)
        {
            var taskFromDb = await _context.Task
                .Where(t=>t.IsDeleted==false)
                .Include(t => t.User)
                .Include(t => t.Status)
                .SingleOrDefaultAsync(t => t.TaskId == id);

            return taskFromDb;
        }

        public async Task<bool> UpdateTaskByIdAsync(int id, Models.Task task)
        {
            var taskFromDb = await GetTaskByIdAsync(id);
            if (taskFromDb is null)
            {
                return false;
            }
            taskFromDb.TaskName = task.TaskName;
            taskFromDb.UserId = task.UserId;
            taskFromDb.StatusId = task.StatusId;
            taskFromDb.Description = task.Description;
            taskFromDb.StartDate = task.StartDate;
            taskFromDb.EndDate = task.EndDate;

            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<Boolean> ChangeStatus(int TaskId, int StatusId)
        {
            var result = await _context.Task.FirstOrDefaultAsync(t => t.TaskId == TaskId);
            if(result==null)
            {
                return false;
            }

            var status = await _context.Status.FirstOrDefaultAsync(s => s.StatusId == StatusId);
            if(status==null)
            {
                return false;
            }

            result.StatusId = StatusId;
            if (await _context.SaveChangesAsync() < 0)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<Models.Task>> GetAllTasks()
        {
            return await _context.Task.Where(t => t.IsDeleted == false).Include(t => t.Status).Include(t => t.User).ToListAsync();
        }

        public async Task<bool> CreateTaskAsync(Models.Task task)
        {
            await _context.Task.AddAsync(task);
            return await _context.SaveChangesAsync() >= 0;
        }


        public async Task<bool> DeleteTaskAsync(int id)
        {
            var taskFromDb = await _context.Task.SingleOrDefaultAsync(t => t.TaskId == id);
            if (taskFromDb == null)
            {
                return false;
            }

            taskFromDb.IsDeleted = true;
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
