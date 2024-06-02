using FITTNESS.Data.Models;

namespace FITTNESS.Repository.IRepo;
public interface IHomeRepository
{
    Task<Home> GetAsync(int Id);
    Task<List<Home>> GetListAsync();
    Task AddHome(Home home);
    Task UpdateHome(Home home);
    Task DeleteHome(int Id);
}