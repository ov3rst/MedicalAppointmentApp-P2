using MedicalAppointment.Domain.Entities.Appointments;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;

namespace MedicalAppointment.Persistence.Repositories.AppointmentsRepositories
{
    public class AppointmentsRepository : BaseRepository<Appointments, int>
    {
        private readonly AppointmentDbContext _context;

        public AppointmentsRepository(AppointmentDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
