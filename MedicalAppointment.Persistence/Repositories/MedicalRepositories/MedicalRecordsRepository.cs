using MedicalAppointment.Domain.Entities.Medical;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;

namespace MedicalAppointment.Persistence.Repositories.MedicalRepositories
{
    public class MedicalRecordsRepository : BaseRepository<MedicalRecords, int>
    {
        private readonly AppointmentDbContext _context;

        public MedicalRecordsRepository(AppointmentDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
