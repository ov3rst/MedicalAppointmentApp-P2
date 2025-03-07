using MedicalAppointment.Persistence.Interfaces.UsersRepositories;
using MedicalAppointment.Persistence.Repositories.UsersRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalAppointment.IOC.Repositories
{
    public static class UsersRepositoryDependencies
    {
        public static void AddUsersRepositories(IServiceCollection services)
        {
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
