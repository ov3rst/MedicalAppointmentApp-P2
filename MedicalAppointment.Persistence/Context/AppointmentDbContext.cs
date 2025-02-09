using Microsoft.EntityFrameworkCore;

namespace MedicalAppointment.Persistence.Context
{
    public partial class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options)
        {

        }
    }
}
