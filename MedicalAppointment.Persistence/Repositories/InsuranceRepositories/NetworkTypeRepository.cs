using MedicalAppointment.Domain.Entities.Insurance;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;

namespace MedicalAppointment.Persistence.Repositories.InsuranceRepositories
{
    public class NetworkTypeRepository : BaseRepository<NetworkType, int>
    {
        private readonly AppointmentDbContext _context;

        public NetworkTypeRepository(AppointmentDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
