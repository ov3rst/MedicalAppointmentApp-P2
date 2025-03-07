using MedicalAppointment.Application.Contracts_Interfaces_.Users;
using MedicalAppointment.Application.Services.UsersServices;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalAppointment.IOC.Services
{
    public static class UsersServicesDependencies
    {
        public static void AddUsersServices(IServiceCollection services)
        {
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
