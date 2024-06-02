using FITTNESS.Data;
using FITTNESS.Data.Models;
using FITTNESS.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace FITTNESS.Repository.Repo;

public class ProfileUserRepository : IProfileUserRepository
{
    private readonly AppDBContext _db;

    public ProfileUserRepository(AppDBContext db)
    {
        _db = db;
    }
    public async Task AddProfileUser(ProfileUser profileuser)
    {
        await _db.ProfileUser.AddAsync(profileuser);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteProfileUser(int Id)
    {
        var data = await _db.ProfileUser.FindAsync(Id);
        if (data != null)
        {
            _db.ProfileUser.Remove(data);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<ProfileUser> GetAsync(int Id)
    {
        var data = await _db.ProfileUser.FindAsync(Id);
        return data;
    }

    public async Task<List<ProfileUser>> GetListAsync()
    {
        var data = await _db.ProfileUser.ToListAsync();
        return data;
    }

    public async Task UpdateProfileUser(ProfileUser profileuser)
    {
        var data = await _db.ProfileUser.FindAsync(profileuser.Id);
        if (data != null)
        {
            data.Id= profileuser.Id;
            data.FullName= profileuser.FullName;
            data.Email= profileuser.Email;
            data.Address= profileuser.Address;
            data.PhoneNumber= profileuser.PhoneNumber;
            data.Country= profileuser.Country;
            data.Img= profileuser.Img;

            _db.ProfileUser.Update(data);
            _db.SaveChanges();
        }
    }
}