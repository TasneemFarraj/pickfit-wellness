using FITTNESS.Data.Enum;
using FITTNESS.Data.Models;

namespace FITTNESS.Repository.IRepo;
public interface IInformationCardRepository
{
    Task<InformationCard> GetAsync(int Id);
    Task<List<InformationCard>> GetList();
    Task<List<InformationCard>> GetListAsync();
    Task AddInformationCard(InformationCard informationcard);
    Task UpdateInformationCard(InformationCard informationcard);
    Task DeleteInformationCard(int Id);
    Task<List<InformationCard>> GetInformationCardBySpecialistType(SpecialistTypeEnum SpecialistType);
    Task ActiveInformationCard(int Id, bool IsActive);
}
