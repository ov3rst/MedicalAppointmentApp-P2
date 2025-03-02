using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.DTOs.UsersDTOs.Patients;

namespace MedicalAppointment.Application.Contracts_Interfaces_.Users
{
    public interface IPatientService : IBaseService<SavePatientDTO, UpdatePatientDTO, RemovePatientDTO, int>
    {
    }
}
