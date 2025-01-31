using Microsoft.AspNetCore.Mvc;
using TaskMasterApi.Interfaces;
using TaskMasterApi.Data.Models;

namespace TaskMasterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int idTask = default, string? title = null, int page = 1, int pageSize = 10)
        {
            var result = await _service.Get(idTask, title, page, pageSize);
            if (result.Count == 0) return NotFound(new { message = "Task not found." });

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(TaskRequest task)
        {
            var result = await _service.Create(task);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, TaskRequest task)
        {
            var result = await _service.Update(id, task);
            if (!result) return NotFound(new { message = "Task not found." });

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            if (!result) return NotFound(new { message = "Task not found." });

            return NoContent();
        }
    }
}
