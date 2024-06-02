using FITTNESS.Data.Models;

namespace FITTNESS.Repository.IRepo;

public interface IUserRepository
{
    Task<User> GetAsync(int Id);
    Task<List<User>> GetListAsync();
    Task AddUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(int Id);
    Task<User> LoginUser(User user);
}
