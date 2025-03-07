using MedicalAppointment.Application.Contracts_Interfaces_.System;
using MedicalAppointment.Application.Services.SystemServices;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalAppointment.IOC.Services
{
    public static class SystemServicesDependencies
    {
        public static void AddSystemServices(IServiceCollection services)
        {
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IRolesService, RolesService>();
            services.AddScoped<IStatusService, StatusService>();
        }
    }
}
