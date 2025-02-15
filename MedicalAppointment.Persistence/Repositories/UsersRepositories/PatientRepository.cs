using MedicalAppointment.Domain.Entities.Users;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;

namespace MedicalAppointment.Persistence.Repositories.UsersRepositories
{
    public class PatientRepository : BaseRepository<Patient, int>
    {
        private readonly AppointmentDbContext _context;

        public PatientRepository(AppointmentDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
