using MedicalAppointment.Domain.Entities.Users;
using MedicalAppointment.Domain.Repository;

namespace MedicalAppointment.Persistence.Interfaces.UsersRepositories
{
    public interface IPatientRepository : IBaseRepository<Patient, int>
    {
    }
}
