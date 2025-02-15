using MedicalAppointment.Domain.Entities.Medical;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointment.Persistence.Context
{
    public partial class AppointmentDbContext
    {
        public DbSet<AvailabilityModes> AvailabilityModes { get; set; }
        public DbSet<MedicalRecords> MedicalRecords { get; set; }
        public DbSet<Specialties> Specialties { get; set; }
    }
}
