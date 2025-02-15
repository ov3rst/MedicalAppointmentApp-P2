using MedicalAppointment.Domain.Entities.Insurance;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;

namespace MedicalAppointment.Persistence.Repositories.InsuranceRepositories
{
    public class InsuranceProviderRepository : BaseRepository<InsuranceProvider, int>
    {
        private readonly AppointmentDbContext _context;

        public InsuranceProviderRepository(AppointmentDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
