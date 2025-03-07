using MedicalAppointment.Application.Contracts_Interfaces_.Medical;
using MedicalAppointment.Application.Services.MedicalServices;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalAppointment.IOC.Services
{
    public static class MedicalServicesDependencies
    {
        public static void AddMedicalServices(IServiceCollection services)
        {
            services.AddScoped<IAvailabilityModesService, AvailabilityModesService>();
            services.AddScoped<IMedicalRecordService, MedicalRecordsService>();
            services.AddScoped<ISpecialtiesService, SpecialtiesService>();
        }
    }
}
