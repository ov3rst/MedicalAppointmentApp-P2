using MedicalAppointment.Domain.SecurityInterfaces;
using MedicalAppointment.Infraestructure;
using MedicalAppointment.Infraestructure.Security;
using MedicalAppointment.IOC.Repositories;
using MedicalAppointment.IOC.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalAppointment.IOC.Configuration
{
    public static class AddAllDependencies
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            #region Repositories
            AppointmentRepositoryDependencies.AddAppointmentRepositories(services);
            InsuranceRepositoryDependencies.AddInsuranceRepositories(services);
            MedicalRepositoryDependencies.AddMedicalRepositories(services);
            SystemRepositoryDependencies.AddSystemRepositories(services);
            UsersRepositoryDependencies.AddUsersRepositories(services);
            #endregion

            #region Services
            AppointmentServicesDependencies.AddAppointmentServices(services);
            InsuranceServicesDependencies.AddInsuranceServices(services);
            MedicalServicesDependencies.AddMedicalServices(services);
            SystemServicesDependencies.AddSystemServices(services);
            UsersServicesDependencies.AddUsersServices(services);
            #endregion

            services.AddSingleton<IJwtService, JwtService>();
            services.AddSingleton<IHashService, HashService>();
            services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));
        }
    }
}
