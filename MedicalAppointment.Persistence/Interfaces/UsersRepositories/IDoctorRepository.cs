using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Users;
using MedicalAppointment.Domain.Repository;

namespace MedicalAppointment.Persistence.Interfaces.UsersRepositories
{
    public interface IDoctorRepository : IBaseRepository<Doctor, int>
    {
        Task<OperationResult> GetDoctorBySpecialty(int specialtyId);
    }
}
