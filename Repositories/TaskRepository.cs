using Microsoft.EntityFrameworkCore;
using TaskAPI.Data;
using TaskAPI.Models;

namespace TaskAPI.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaskModel> GetByIdAsync(int id) => await _context.Task.FindAsync(id);
        public async Task<List<TaskModel>> GetAllAsync() => await _context.Task.ToListAsync();
        public async Task CreateAsync(TaskModel task)
        {
            await _context.Task.AddAsync(task);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(TaskModel task)
        {
            _context.Task.Update(task);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var task = await GetByIdAsync(id);
            _context.Task.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}
