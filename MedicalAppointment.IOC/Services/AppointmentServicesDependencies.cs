using MedicalAppointment.Application.Contracts_Interfaces_.Appointments;
using MedicalAppointment.Application.Services.AppointmentsServices;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalAppointment.IOC.Services
{
    public static class AppointmentServicesDependencies
    {
        public static void AddAppointmentServices(IServiceCollection services)
        {
            services.AddScoped<IAppointmentService, AppointmentsService>();
            services.AddScoped<IDoctorAvailabilityService, DoctorAvailabilityService>();
        }
    }
}
