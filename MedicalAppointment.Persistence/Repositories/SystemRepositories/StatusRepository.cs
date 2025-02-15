using MedicalAppointment.Domain.Entities.System;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;

namespace MedicalAppointment.Persistence.Repositories.SystemRepositories
{
    public class StatusRepository : BaseRepository<Status, int>
    {
        private readonly AppointmentDbContext _context;

        public StatusRepository(AppointmentDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
