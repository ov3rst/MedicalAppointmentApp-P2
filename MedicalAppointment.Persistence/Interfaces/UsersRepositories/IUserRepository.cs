using MedicalAppointment.Domain.Entities.Users;
using MedicalAppointment.Domain.Repository;

namespace MedicalAppointment.Persistence.Interfaces.UsersRepositories
{
    internal interface IUserRepository : IBaseRepository<Users, int>
    {
    }
}
