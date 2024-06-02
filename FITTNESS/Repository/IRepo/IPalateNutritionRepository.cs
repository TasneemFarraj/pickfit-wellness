using FITTNESS.Data.Models;

namespace FITTNESS.Repository.IRepo;
public interface IPalateNutritionRepository
{
    Task<PalateNutrition> GetAsync(int Id);
    Task<List<PalateNutrition>> GetListAsync();
    Task AddPalateNutrition(PalateNutrition nutrition);
    Task UpdatePalateNutrition(PalateNutrition nutrition);
    Task DeletePalateNutrition(int Id);

}
