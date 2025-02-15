using MedicalAppointment.Domain.Entities.Users;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;
using MedicalAppointment.Persistence.Interfaces.UsersRepositories;

namespace MedicalAppointment.Persistence.Repositories.UsersRepositories
{
    public class UserRepository(AppointmentDbContext context) : BaseRepository<User, int>(context), IUserRepository
    {
        private readonly AppointmentDbContext _context = context;

    }
}
