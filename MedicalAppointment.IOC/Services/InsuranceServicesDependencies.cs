using MedicalAppointment.Application.Contracts_Interfaces_.Insurance;
using MedicalAppointment.Application.Services.InsuranceServices;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalAppointment.IOC.Services
{
    public static class InsuranceServicesDependencies
    {
        public static void AddInsuranceServices(IServiceCollection services)
        {
            services.AddScoped<IInsuranceProviderService, InsuranceProviderService>();
            services.AddScoped<INetworkTypeService, NetworkTypeService>();
        }
    }
}
