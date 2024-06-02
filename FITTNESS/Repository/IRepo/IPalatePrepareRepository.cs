using FITTNESS.Data.Models;

namespace FITTNESS.Repository.IRepo
{
    public interface IPalatePrepareRepository
    {
        Task<PalatePrepare> GetAsync(int Id);
        Task<List<PalatePrepare>> GetListAsync();
        Task AddPrepare(PalatePrepare prepare);
        Task UpdatePrepare(PalatePrepare prepare);
        Task DeletePrepare(int Id);
    }
}