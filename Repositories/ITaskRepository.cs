using TaskAPI.Models;

namespace TaskAPI.Repositories
{
    public interface ITaskRepository
    {
        Task<TaskModel> GetByIdAsync(int id);
        Task<List<TaskModel>> GetAllAsync();
        Task CreateAsync(TaskModel task);
        Task UpdateAsync(TaskModel task);
        Task DeleteAsync(int id);
    }
}
