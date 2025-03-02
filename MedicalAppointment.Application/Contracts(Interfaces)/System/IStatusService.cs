using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.DTOs.SystemDTOs.Status;

namespace MedicalAppointment.Application.Contracts_Interfaces_.System
{
    public interface IStatusService : IBaseService<SaveStatusDTO, UpdateStatusDTO, RemoveStatusDTO, int>
    {
    }
}
