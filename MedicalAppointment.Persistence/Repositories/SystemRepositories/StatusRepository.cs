using MedicalAppointment.Domain.Entities.System;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;
using MedicalAppointment.Persistence.Interfaces.SystemRepositories;

namespace MedicalAppointment.Persistence.Repositories.SystemRepositories
{
    public class StatusRepository : BaseRepository<Status, int>, IStatusRepository
    {
        private readonly AppointmentDbContext _context;

        public StatusRepository(AppointmentDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
