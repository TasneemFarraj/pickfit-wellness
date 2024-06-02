using FITTNESS.Data;
using FITTNESS.Data.Models;
using FITTNESS.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace FITTNESS.Repository.Repo
{
    public class PalatePrepareRepository : IPalatePrepareRepository
    {
        private readonly AppDBContext _db;

        public PalatePrepareRepository(AppDBContext db)
        {
            _db = db;
        }
        public async Task AddPrepare(PalatePrepare prepare)
        {
            await _db.PalatePrepare.AddAsync(prepare);
            await _db.SaveChangesAsync();
        }

        public async Task DeletePrepare(int Id)
        {
            var data = await _db.PalatePrepare.FindAsync(Id);
            if (data != null)
            {
                _db.PalatePrepare.Remove(data);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<PalatePrepare> GetAsync(int Id)
        {
            var data = await _db.PalatePrepare.FindAsync(Id);
            return data;
        }

        public async Task<List<PalatePrepare>> GetListAsync()
        {
            var data = await _db.PalatePrepare.ToListAsync();
            return data;
        }

        public async Task UpdatePrepare(PalatePrepare prepare)
        {
            var data = await _db.PalatePrepare.FindAsync(prepare.Id);
            if (data != null)
            {
                data.step_1 = prepare.step_1;
                data.step_2 = prepare.step_2;
                data.step_3 = prepare.step_3;
                data.step_4 = prepare.step_4;
                data.step_5 = prepare.step_5;
                data.step_6 = prepare.step_6;
                data.step_7 = prepare.step_7;

                _db.PalatePrepare.Update(data);
                _db.SaveChanges();
            }
        }
    }
}
