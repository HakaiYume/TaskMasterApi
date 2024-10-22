using TaskMasterApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Task = TaskMasterApi.Data.Models.Task;
using TaskMasterApi.Data;

namespace TaskMasterApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskMasterBdContext _context;

        public TaskService(TaskMasterBdContext context)
        {
            _context = context;
        }

        public async Task<List<TaskResponse>> Get(int idTask, string? title, int page, int pageSize)
        {
            var result = await _context.Tasks
                .Where(t => 
                    (idTask == default || t.IdTask == idTask) &&
                    (string.IsNullOrEmpty(title) || t.Title.Contains(title)))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return result.Select(t => MapTaskResponse(t)).ToList();
        }

        public async Task<TaskResponse> Create(TaskRequest taskRequest)
        {
            var task = MapTask(taskRequest);
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return MapTaskResponse(task);
        }

        public async Task<bool> Update(int id, TaskRequest taskRequest)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            task.Title = taskRequest.Title;
            task.Description = taskRequest.Description;
            task.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        private TaskResponse MapTaskResponse(Task task)
        {
            return new TaskResponse
            {
                IdTask = task.IdTask,
                Title = task.Title,
                Description = task.Description,
                CreatedAt = task.CreatedAt,
                UpdatedAt = task.UpdatedAt
            };
        }

        private Task MapTask(TaskRequest taskRequest)
        {
            return new Task
            {
                Title = taskRequest.Title,
                Description = taskRequest.Description,
                CreatedAt = DateTime.Now
            };
        }
    }
}
