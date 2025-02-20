using MedicalAppointment.Persistence.Interfaces.AppointmentsRepositories;
using MedicalAppointment.Persistence.Interfaces.InsuranceRepositories;
using MedicalAppointment.Persistence.Interfaces.MedicalRepositories;
using MedicalAppointment.Persistence.Interfaces.SystemRepositories;
using MedicalAppointment.Persistence.Interfaces.UsersRepositories;
using MedicalAppointment.Persistence.Repositories.AppointmentsRepositories;
using MedicalAppointment.Persistence.Repositories.InsuranceRepositories;
using MedicalAppointment.Persistence.Repositories.MedicalRepositories;
using MedicalAppointment.Persistence.Repositories.SystemRepositories;
using MedicalAppointment.Persistence.Repositories.UsersRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalAppointment.IOC.Configuration
{
    public static class RepositoryDependencies
    {
        public static void AddRepositoryDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();
            services.AddScoped<IDoctorAvailabilityRepository, DoctorAvailabilityRepository>();
            services.AddScoped<IInsuranceProviderRepository, InsuranceProviderRepository>();
            services.AddScoped<INetworkTypeRepository, NetworkTypeRepository>();
            services.AddScoped<IAvailabilityModesRepository, AvailabilityModesRepository>();
            services.AddScoped<IMedicalRecordsRepository, MedicalRecordsRepository>();
            services.AddScoped<ISpecialtiesRepository, SpecialtiesRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
