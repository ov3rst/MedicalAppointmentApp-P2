using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.DTOs.MedicalDTOs.AvailabilityModes;

namespace MedicalAppointment.Application.Contracts_Interfaces_.Medical
{
    public interface IAvailavilityModesService : IBaseService<SaveAvailabilityModesDTO, UpdateAvailabilityModesDTO, RemoveAvailabilityModesDTO, short>
    {
    }
}
