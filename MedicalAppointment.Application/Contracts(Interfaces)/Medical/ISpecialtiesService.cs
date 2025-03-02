using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.DTOs.MedicalDTOs.Specialties;

namespace MedicalAppointment.Application.Contracts_Interfaces_.Medical
{
    public interface ISpecialtiesService : IBaseService<SaveSpecialtiesDTO, UpdateSpecialtiesDTO, RemoveSpecialtiesDTO, short>
    {
    }
}
