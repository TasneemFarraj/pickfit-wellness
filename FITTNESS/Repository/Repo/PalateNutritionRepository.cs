using FITTNESS.Data;
using FITTNESS.Data.Models;
using FITTNESS.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace FITTNESS.Repository.Repo
{
    public class PalateNutritionRepository : IPalateNutritionRepository
    {

        private readonly AppDBContext _db;

        public PalateNutritionRepository(AppDBContext db)
        {
            _db = db;
        }
        public async Task AddPalateNutrition(PalateNutrition nutrition)
        {
            await _db.PalateNutrition.AddAsync(nutrition);
            await _db.SaveChangesAsync();
        }

        public async Task DeletePalateNutrition(int Id)
        {
            var data = await _db.PalateNutrition.FindAsync(Id);
            if (data != null)
            {
                _db.PalateNutrition.Remove(data);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<PalateNutrition> GetAsync(int Id)
        {
            var data = await _db.PalateNutrition.FindAsync(Id);
            return data;
        }

        public async Task<List<PalateNutrition>> GetListAsync()
        {
            var data = await _db.PalateNutrition.ToListAsync();
            return data;
        }

        public async Task UpdatePalateNutrition(PalateNutrition Nutrition)
        {
            var data = await _db.PalateNutrition.FindAsync(Nutrition.Id);
            if (data != null)
            {
                data.Id = Nutrition.Id;
                data.Fats = Nutrition.Fats;
                data.Protein = Nutrition.Protein;
                data.Carbohydrates = Nutrition.Carbohydrates;
                data.Calories = Nutrition.Calories;

                _db.PalateNutrition.Update(data);
                _db.SaveChanges();
            }
        }
    }
}
