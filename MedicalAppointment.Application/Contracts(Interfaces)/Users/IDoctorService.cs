using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.DTOs.UsersDTOs.Doctors;
using MedicalAppointment.Domain.Base;

namespace MedicalAppointment.Application.Contracts_Interfaces_.Users
{
    public interface IDoctorService : IBaseService<SaveDoctorDTO, UpdateDoctorDTO, RemoveDoctorDTO, int>
    {
        Task<OperationResult> GetDoctorBySpecialty(int specialtyId);
    }
}
