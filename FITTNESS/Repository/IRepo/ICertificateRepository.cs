using FITTNESS.Data.Models;

namespace FITTNESS.Repository.IRepo
{
    public interface ICertificateRepository
    {
        Task<Certificate> GetAsync(int Id);
        Task<List<Certificate>> GetListAsync();
        Task AddCertificate(Certificate certificate);
        Task UpdateCertificate(Certificate certificate);
        Task DeleteCertificate(int Id);
    }
}
