using FITTNESS.Data.Models;

namespace FITTNESS.Repository.IRepo
{
    public interface IPalateRecipeRepository
    {
        Task<PalateRecipe> GetAsync(int Id);
        Task<List<PalateRecipe>> GetListAsync();
        Task AddRecipe(PalateRecipe recipe);
        Task UpdateRecipe(PalateRecipe recipe);
        Task DeleteRecipe(int Id);
    }
}
