using MedicalAppointment.IOC.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalAppointment.IOC.Configuration
{
    public static class AddAllDependencies
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            #region Repositories
            AppointmentRepositoryDependencies.AddAppointmentDependencies(services);
            InsuranceRepositoryDependencies.AddInsuranceDependencies(services);
            MedicalRepositoryDependencies.AddMedicalDependencies(services);
            SystemRepositoryDependencies.AddSystemDependencies(services);
            UsersRepositoryDependencies.AddUsersDependencies(services);
            #endregion


        }
    }
}
