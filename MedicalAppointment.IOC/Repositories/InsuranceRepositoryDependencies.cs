using MedicalAppointment.Persistence.Interfaces.InsuranceRepositories;
using MedicalAppointment.Persistence.Repositories.InsuranceRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalAppointment.IOC.Repositories
{
    public static class InsuranceRepositoryDependencies
    {
        public static void AddInsuranceRepositories(IServiceCollection services)
        {
            services.AddScoped<IInsuranceProviderRepository, InsuranceProviderRepository>();
            services.AddScoped<INetworkTypeRepository, NetworkTypeRepository>();
        }
    }
}
