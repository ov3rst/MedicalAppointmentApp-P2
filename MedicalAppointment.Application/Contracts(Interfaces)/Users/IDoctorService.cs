using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.DTOs.UsersDTOs.Doctors;

namespace MedicalAppointment.Application.Contracts_Interfaces_.Users
{
    public interface IDoctorService : IBaseService<SaveDoctorDTO, UpdateDoctorDTO, RemoveDoctorDTO, int>
    {
    }
}
