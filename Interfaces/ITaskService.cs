using TaskMasterApi.Data.Models;
using TaskMasterApi.Data.Response;

namespace TaskMasterApi.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskResponse>> Get(int idTask, string? title, int page, int pageSize);
        Task<TaskResponse> Create(TaskRequest taskRequest);
        Task<bool> Update(int id, TaskRequest taskRequest);
        Task<bool> Delete(int id);
    }
}
