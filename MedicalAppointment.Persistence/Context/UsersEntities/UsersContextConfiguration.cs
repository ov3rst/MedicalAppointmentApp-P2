using MedicalAppointment.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointment.Persistence.Context
{
    public partial class AppointmentDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
