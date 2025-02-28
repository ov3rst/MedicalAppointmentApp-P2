using MedicalAppointment.Persistence.Interfaces.MedicalRepositories;
using MedicalAppointment.Persistence.Repositories.MedicalRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalAppointment.IOC.Repositories
{
    public static class MedicalRepositoryDependencies
    {
        public static void AddMedicalDependencies(IServiceCollection services)
        {
            services.AddScoped<IAvailabilityModesRepository, AvailabilityModesRepository>();
            services.AddScoped<IMedicalRecordsRepository, MedicalRecordsRepository>();
            services.AddScoped<ISpecialtiesRepository, SpecialtiesRepository>();
        }
    }
}
