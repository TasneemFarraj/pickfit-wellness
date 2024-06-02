using FITTNESS.Data;
using FITTNESS.Data.Models;
using FITTNESS.Repository.IRepo;
using Microsoft.EntityFrameworkCore;


namespace FITTNESS.Repository.Repo
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDBContext _db;

        public AppointmentRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task AddAppointment(Appointment appointment)
        {

            await _db.Appointment.AddAsync(appointment);
            await _db.SaveChangesAsync();

        }

        public async Task DeleteAppointment(int Id)
        {
            var data = await _db.Appointment.FindAsync(Id);
            if (data != null)
            {
                _db.Appointment.Remove(data);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Appointment> GetAsync(int Id)
        {
            var data = await _db.Appointment.FindAsync(Id);
            return data;
        }

        public async Task<List<Appointment>> GetListAsync()
        {
            var data = await _db.Appointment.Include(x=>x.InformationCard).ToListAsync();
            return data;
        }

        public async Task UpdateAppointment(Appointment appointment)
        {
            var data = await _db.Appointment.FindAsync(appointment.Id);
            if (data != null)
            {
                data.Id = appointment.Id;
                data.Name = appointment.Name;
                data.PhoneNumber= appointment.PhoneNumber;
                data.Date = appointment.Date;
                data.Time = appointment.Time;
               
                _db.Appointment.Update(data);
                _db.SaveChanges();
            }
        }
    }
}
