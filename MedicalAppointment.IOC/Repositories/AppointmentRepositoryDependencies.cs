using MedicalAppointment.Persistence.Interfaces.AppointmentsRepositories;
using MedicalAppointment.Persistence.Repositories.AppointmentsRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalAppointment.IOC.Repositories
{
    public static class AppointmentRepositoryDependencies
    {
        public static void AddAppointmentDependencies(IServiceCollection services)
        {
            services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();
            services.AddScoped<IDoctorAvailabilityRepository, DoctorAvailabilityRepository>();
        }
    }
}
