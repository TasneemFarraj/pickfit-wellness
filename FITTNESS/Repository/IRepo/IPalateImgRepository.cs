using FITTNESS.Data.Models;

namespace FITTNESS.Repository.IRepo
{
    public interface IPalateImgRepository
    {
        Task<PalateImg> GetAsync(int Id);
        Task<List<PalateImg>> GetListAsync();
        Task AddPalateImg(PalateImg palateimg);
        Task UpdatePalateImg(PalateImg palateimg);
        Task DeletePalateImg(int Id);
    }
}
