using MedicalAppointment.Domain.Entities.Appointments;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;

namespace MedicalAppointment.Persistence.Repositories.AppointmentsRepositories
{
    public class DoctorAvailabilityRepository : BaseRepository<DoctorAvailability, int>
    {
        private readonly AppointmentDbContext _dbContext;

        public DoctorAvailabilityRepository(AppointmentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
