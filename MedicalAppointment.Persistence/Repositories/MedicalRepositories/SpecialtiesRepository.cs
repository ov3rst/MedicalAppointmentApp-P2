using MedicalAppointment.Domain.Entities.Medical;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;

namespace MedicalAppointment.Persistence.Repositories.MedicalRepositories
{
    public class SpecialtiesRepository : BaseRepository<Specialties, short>
    {
        private readonly AppointmentDbContext _context;

        public SpecialtiesRepository(AppointmentDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
