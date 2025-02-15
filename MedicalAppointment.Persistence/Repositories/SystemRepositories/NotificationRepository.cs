using MedicalAppointment.Domain.Entities.System;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;

namespace MedicalAppointment.Persistence.Repositories.SystemRepositories
{
    public class NotificationRepository : BaseRepository<Notification, int>
    {
        private readonly AppointmentDbContext _context;

        public NotificationRepository(AppointmentDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
