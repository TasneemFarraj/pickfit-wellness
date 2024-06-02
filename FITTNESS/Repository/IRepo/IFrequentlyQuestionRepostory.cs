using FITTNESS.Data.Models;

namespace FITTNESS.Repository.IRepo
{
    public interface IFrequentlyQuestionRepository
    {
        Task<FrequentlyQuestion> GetAsync(int Id);
        Task<List<FrequentlyQuestion>> GetListAsync();
        Task AddQuestion(FrequentlyQuestion FrequentlyQuestion);
        Task UpdateQuestion(FrequentlyQuestion FrequentlyQuestion);
        Task DeleteQuestion(int Id);
    }
}
