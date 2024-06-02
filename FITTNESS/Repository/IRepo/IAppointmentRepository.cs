using FITTNESS.Data.Models;

namespace FITTNESS.Repository.IRepo
{
    public interface IAppointmentRepository
    {

        Task<Appointment> GetAsync(int Id);
        Task<List<Appointment>> GetListAsync();
        Task AddAppointment(Appointment appointment);
        Task UpdateAppointment(Appointment appointment);
        Task DeleteAppointment(int Id);
    }
}
