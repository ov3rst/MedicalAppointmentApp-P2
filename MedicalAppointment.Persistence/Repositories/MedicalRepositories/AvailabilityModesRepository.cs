using MedicalAppointment.Domain.Entities.Medical;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;

namespace MedicalAppointment.Persistence.Repositories.MedicalRepositories
{
    public class AvailabilityModesRepository : BaseRepository<AvailabilityModes, short>
    {
        private readonly AppointmentDbContext _context;

        public AvailabilityModesRepository(AppointmentDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
