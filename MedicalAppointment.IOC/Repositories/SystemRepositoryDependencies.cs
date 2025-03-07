using MedicalAppointment.Persistence.Interfaces.SystemRepositories;
using MedicalAppointment.Persistence.Repositories.SystemRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalAppointment.IOC.Repositories
{
    public static class SystemRepositoryDependencies
    {
        public static void AddSystemRepositories(IServiceCollection services)
        {
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
        }
    }
}
