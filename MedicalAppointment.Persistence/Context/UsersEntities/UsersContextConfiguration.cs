using MedicalAppointment.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointment.Persistence.Context.UsersEntities
{
    public partial class AppointmentDbContext
    {
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
