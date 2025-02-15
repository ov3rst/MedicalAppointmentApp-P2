using MedicalAppointment.Domain.Entities.System;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;

namespace MedicalAppointment.Persistence.Repositories.SystemRepositories
{
    public class RolesRepository : BaseRepository<Roles, int>
    {
        private readonly AppointmentDbContext _context;

        public RolesRepository(AppointmentDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
