using Microsoft.EntityFrameworkCore;
using TaskAPI.Data;
using TaskAPI.Models;

namespace TaskAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> GetByIdAsync(int id) => await _context.User.FindAsync(id);
        public async Task<List<UserModel>> GetAllAsync() => await _context.User.ToListAsync();
        public async Task CreateAsync(UserModel user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(UserModel user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
