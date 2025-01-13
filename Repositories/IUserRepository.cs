using TaskAPI.Models;

namespace TaskAPI.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel> GetByIdAsync(int id);
        Task<List<UserModel>> GetAllAsync();
        Task CreateAsync(UserModel user);
        Task UpdateAsync(UserModel user);
        Task DeleteAsync(int id);
    }
}
