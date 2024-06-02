using FITTNESS.Data;
using FITTNESS.Data.Models;
using FITTNESS.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace FITTNESS.Repository.Repo
{
    public class PalateRecipeRepository : IPalateRecipeRepository
    {
        private readonly AppDBContext _db;

        public PalateRecipeRepository(AppDBContext db)
        {
            _db = db;
        }
        public async Task AddRecipe(PalateRecipe recipe)
        {
            await _db.PalateRecipe.AddAsync(recipe);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRecipe(int Id)
        {
            var data = await _db.PalateRecipe.FindAsync(Id);
            if (data != null)
            {
                _db.PalateRecipe.Remove(data);
                await _db.SaveChangesAsync();
            }
        }
        public async Task UpdateRecipe(PalateRecipe recipe)
        {
            var data = await _db.PalateRecipe.FindAsync(recipe.Id);
            if (data != null)
            {
                data.Id = recipe.Id;
                data.PreparationTime = recipe.PreparationTime;
                data.CookingTime = recipe.CookingTime;
                data.NumberOfPeople = recipe.NumberOfPeople;
                data.DifficultyLevel = recipe.DifficultyLevel;

                _db.PalateRecipe.Update(data);
                _db.SaveChanges();
            }
        }
        public async Task<PalateRecipe> GetAsync(int Id)
        {
            var data = await _db.PalateRecipe.FindAsync(Id);
            return data;
        }

        public async Task<List<PalateRecipe>> GetListAsync()
        {
            var data = await _db.PalateRecipe.ToListAsync();
            return data;
        }
    }
}
