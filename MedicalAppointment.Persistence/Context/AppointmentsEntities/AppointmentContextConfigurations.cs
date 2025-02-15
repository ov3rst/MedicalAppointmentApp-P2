﻿using MedicalAppointment.Domain.Entities.Appointments;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointment.Persistence.Context
{
    public partial class AppointmentDbContext
    {
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<DoctorAvailability> DoctorAvailability { get; set; }
    }
}
