using MedicalAppointment.Domain.Entities.Appointments;
using MedicalAppointment.Domain.Repository;

namespace MedicalAppointment.Persistence.Interfaces.AppointmentsRepositories
{
    public interface IDoctorAvailabilityRepository : IBaseRepository<DoctorAvailability, int>
    {
    }
}
