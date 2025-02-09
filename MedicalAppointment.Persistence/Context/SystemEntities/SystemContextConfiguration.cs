using MedicalAppointment.Domain.Entities.System;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointment.Persistence.Context.SystemEntities
{
    public partial class AppointmentDbContext
    {
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}
