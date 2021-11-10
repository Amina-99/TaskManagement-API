using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskmanagementAPI_Beta.Domain;
using TaskmanagementAPI_Beta.Models.Dtos;

namespace TaskmanagementAPI_Beta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var result = await _taskService.GetAllTasks();
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Something went wrong fetching data!");
            }
        }

        [HttpPut("status/{taskId}/{statusId}")]
        public async Task<IActionResult> ChangeStatus(int taskId, int statusId)
        {
            var result = await _taskService.ChangeStatus(taskId, statusId);
            return result ? Ok() : BadRequest("Something went wrong updating data"); 
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync([FromBody] TaskCreateDto taskCreateDto)

        {

            await _taskService.CreateTaskAsync(taskCreateDto);

            return StatusCode(201);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskByIdAsync(int id)
        {
            try
            {
                var task = await _taskService.GetTaskByIdAsync(id);
                if (task == null)
                { 
                    return NotFound();
                }
                return Ok(task);
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong: " + e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskAsync(int id, [FromBody] TaskCreateDto taskCreateDto)
        {
            try
            {
                var result = await _taskService.UpdateTaskByIdAsync(id, taskCreateDto);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong: " + e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskAsync(int id)
        {
            try
            {
                var result = await _taskService.DeleteTaskAsync(id);
                if (!result)
                {
                    return BadRequest("Deleting task failed");
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}