using MedicalAppointment.Domain.Entities.Users;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;

namespace MedicalAppointment.Persistence.Repositories.UsersRepositories
{
    public class DoctorRepository : BaseRepository<Doctor, int>
    {
        private readonly AppointmentDbContext _context;

        public DoctorRepository(AppointmentDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
