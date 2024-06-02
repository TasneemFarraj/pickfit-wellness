using FITTNESS.Data;
using FITTNESS.Data.Models;
using FITTNESS.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace FITTNESS.Repository.Repo;

    public class PalateImgRepository : IPalateImgRepository
    {
        private readonly AppDBContext _db;

        public PalateImgRepository(AppDBContext db)
        {
            _db = db;
        }
        public async Task AddPalateImg(PalateImg palateimg)
        {

            await _db.PalateImg.AddAsync(palateimg);
            await _db.SaveChangesAsync();
        }

        public async Task DeletePalateImg(int Id)
        {
            var data = await _db.PalateImg.FindAsync(Id);
            if (data != null)
            {
                _db.PalateImg.Remove(data);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<PalateImg> GetAsync(int Id)
        {
            var data = await _db.PalateImg.FindAsync(Id);
            return data;
        }

        public async Task<List<PalateImg>> GetListAsync()
        {
            var data = await _db.PalateImg.ToListAsync();
            return data;
        }

        public async Task UpdatePalateImg(PalateImg palateimg)
        {
            var data = await _db.PalateImg.FindAsync(palateimg.Id);
            if (data != null)
            {
            data.Id = palateimg.Id;
            data.Img = palateimg.Img;
            data.Title = palateimg.Title;
                _db.PalateImg.Update(data);
                _db.SaveChanges();
            }
        }
}
