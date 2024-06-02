using FITTNESS.Data.Models;

namespace FITTNESS.Repository.IRepo
{
    public interface IPalateIngredientRepository
    {
        Task<PalateIngredient> GetAsync(int Id);
        Task<List<PalateIngredient>> GetListAsync();
        Task AddPalateIngredient(PalateIngredient ingredient);
        Task UpdatePalateIngredient(PalateIngredient ingredient);
        Task DeletePalateIngredient(int Id);
    }
}
