﻿using MedicalAppointment.Domain.Entities.Insurance;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointment.Persistence.Context
{
    public partial class AppointmentDbContext
    {
        public DbSet<InsuranceProvider> InsuranceProvider { get; set; }
        public DbSet<NetworkType> NetworkType { get; set; }
    }
}
