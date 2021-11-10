using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskmanagementAPI_Beta.Data;
using TaskmanagementAPI_Beta.Models.Dtos;

namespace TaskmanagementAPI_Beta.Domain
{
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;
        public TaskService(IMapper mapper, ITaskRepository taskRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        public async Task<bool> ChangeStatus(int TaskId, int StatusId)
        {
            var result = await _taskRepository.ChangeStatus(TaskId, StatusId);
            return result;
        }

        public async Task<IEnumerable<TaskReadDto>> GetAllTasks()
        {
            var result = await _taskRepository.GetAllTasks();
            return _mapper.Map<IEnumerable<TaskReadDto>>(result);
        }

        public async Task CreateTaskAsync(TaskCreateDto taskCreateDto)
        {
            var task = _mapper.Map<Models.Task>(taskCreateDto);
            await _taskRepository.CreateTaskAsync(task);
        }

        public async Task<TaskReadDto> GetTaskByIdAsync(int id)
        {
            var taskFromRepo = await _taskRepository.GetTaskByIdAsync(id);

            return _mapper.Map<TaskReadDto>(taskFromRepo);
        }

        public async Task<bool> UpdateTaskByIdAsync(int id, TaskCreateDto taskCreateDto)
        {
            var task = _mapper.Map<Models.Task>(taskCreateDto);

            return await _taskRepository.UpdateTaskByIdAsync(id, task);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            return await _taskRepository.DeleteTaskAsync(id);
        }
    }
}