using FITTNESS.Data;
using FITTNESS.Data.Models;
using FITTNESS.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace FITTNESS.Repository.Repo
{
    public class FrequentlyQuestionRepository : IFrequentlyQuestionRepository
    {
        private readonly AppDBContext _db;

        public FrequentlyQuestionRepository(AppDBContext db)
        {
            _db = db;
        }
        public async Task AddQuestion(FrequentlyQuestion FrequentlyQuestion)
        {
            await _db.FrequentlyQuestion.AddAsync(FrequentlyQuestion);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteQuestion(int Id)
        {
            var data = await _db.FrequentlyQuestion.FindAsync(Id);
            if (data != null)
            {
                _db.FrequentlyQuestion.Remove(data);
                await _db.SaveChangesAsync();
            }
        }
        public async Task<FrequentlyQuestion> GetAsync(int Id)
        {
            var data = await _db.FrequentlyQuestion.FindAsync(Id);
            return data;
        }
        public async Task<List<FrequentlyQuestion>> GetListAsync()
        {
            var data = await _db.FrequentlyQuestion.ToListAsync();
            return data;
        }
        public async Task UpdateQuestion(FrequentlyQuestion FrequentlyQuestion)
        {
            var data = await _db.FrequentlyQuestion.FindAsync(FrequentlyQuestion.Id);
            if (data != null)
            {
                data.Question = FrequentlyQuestion.Question;
                data.Answer = FrequentlyQuestion.Answer;

                _db.FrequentlyQuestion.Update(data);
                _db.SaveChanges();
            }
        }
    }
}
