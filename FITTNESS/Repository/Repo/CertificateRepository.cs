using FITTNESS.Data;
using FITTNESS.Data.Models;
using FITTNESS.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace FITTNESS.Repository.Repo;

public class CertificateRepository : ICertificateRepository
{
    private readonly AppDBContext _db;

    public CertificateRepository(AppDBContext db)
    {
        _db = db;
    }
    public async Task AddCertificate(Certificate certificate)
    {

        await _db.Certificate.AddAsync(certificate);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteCertificate(int Id)
    {
        var data = await _db.Certificate.FindAsync(Id);
        if (data != null)
        {
            _db.Certificate.Remove(data);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<Certificate> GetAsync(int Id)
    {
        var data = await _db.Certificate.FindAsync(Id);
        return data;
    }

    public async Task<List<Certificate>> GetListAsync()
    {
        var data = await _db.Certificate.ToListAsync();
        return data;
    }

    public async Task UpdateCertificate(Certificate certificate)
    {

        var data = await _db.Certificate.FindAsync(certificate.Id);
        if (data != null)
        {
            data.Id = certificate.Id;
            data.Img = certificate.Img;
        }
    }
}

