using FITTNESS.Data;
using FITTNESS.Data.Models;
using FITTNESS.Repository.IRepo;
using Microsoft.EntityFrameworkCore;
using FITTNESS.Data.Enum;

namespace FITTNESS.Repository.Repo
{
    public class InformationCardRepository : IInformationCardRepository
    {
        private readonly AppDBContext _db;

        public InformationCardRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task AddInformationCard(InformationCard informationcard)
        {
            informationcard.IsActive = false;
            _db.InformationCard.Add(informationcard);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteInformationCard(int Id)
        {
            var data = await _db.InformationCard.FindAsync(Id);
            if (data != null)
            {
                _db.InformationCard.Remove(data);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<InformationCard> GetAsync(int Id)
        {
            return await _db.InformationCard.FindAsync(Id);
        }

        public async Task<List<InformationCard>> GetInformationCardBySpecialistType(SpecialistTypeEnum SpecialistType)
        {
            return await _db.InformationCard.Where(x => x.SpecialistType == SpecialistType).ToListAsync();
        }

        public async Task<List<InformationCard>> GetListAsync()
        {
            return await _db.InformationCard.Where(x => x.IsActive == true).ToListAsync();
        }
        public async Task<List<InformationCard>> GetList()
        {
            return await _db.InformationCard.ToListAsync();
        }
        public async Task UpdateInformationCard(InformationCard informationcard)
        {
            var data = await _db.InformationCard.FindAsync(informationcard.Id);
            if (data != null)
            {
                data.Id = informationcard.Id;
                data.Name = informationcard.Name;
                data.PhoneNumber = informationcard.PhoneNumber;
                data.Addrres = informationcard.Addrres;
                data.Email = informationcard.Email;
                data.WorkingDay = informationcard.WorkingDay;
                data.Rating = informationcard.Rating;
                data.Img = informationcard.Img;
                data.SpecialistType = informationcard.SpecialistType;

                _db.InformationCard.Update(data);
                await _db.SaveChangesAsync();
            }
        }

        public async Task ActiveInformationCard(int Id, bool IsActive)
        {
            var data = await _db.InformationCard.FindAsync(Id);
            if (data != null)
            {
                data.IsActive = IsActive;
                _db.InformationCard.Update(data);
                await _db.SaveChangesAsync();
            }
        }
    }
}
