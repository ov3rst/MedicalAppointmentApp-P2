using MedicalAppointment.Domain.Entities.Users;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;
using MedicalAppointment.Persistence.Repositories.AppointmentsRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistence.Repositories.UsersRepositories
{
    public class DoctorRepository : BaseRepository<Doctor, int>
    {
        private readonly AppointmentDbContext _context;
        private readonly ILogger<AppointmentsRepository> _logger;
        private readonly IConfiguration _configuration;

        public DoctorRepository(AppointmentDbContext context,
                                               ILogger<AppointmentsRepository> logger,
                                               IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }


    }
}
