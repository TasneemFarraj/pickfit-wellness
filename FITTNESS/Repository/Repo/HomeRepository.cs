using FITTNESS.Data;
using FITTNESS.Data.Models;
using FITTNESS.Repository.IRepo;
using Microsoft.EntityFrameworkCore;


namespace FITTNESS.Repository.Repo
{
    public class HomeRepository : IHomeRepository
    {
        private readonly AppDBContext _db;

        public HomeRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task AddHome(Home home)
        {

            await _db.Home.AddAsync(home);
            await _db.SaveChangesAsync();

        }

        public async Task DeleteHome(int Id)
        {
            var data = await _db.Home.FindAsync(Id);
            if (data != null)
            {
                _db.Home.Remove(data);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Home> GetAsync(int Id)
        {
            var data = await _db.Home.FindAsync(Id);
            return data;
        }

        public async Task<List<Home>> GetListAsync()
        {
            var data = await _db.Home.ToListAsync();
            return data;
        }

        public async Task UpdateHome(Home home)
        {
            var data = await _db.Home.FindAsync(home.Id);
            if (data != null)
            {
                data.Id = home.Id;
                data.Name = home.Name;
                _db.Home.Update(data);
                _db.SaveChanges();
            }
        }
    }
}
