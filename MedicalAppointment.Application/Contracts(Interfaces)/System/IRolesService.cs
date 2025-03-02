using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.DTOs.SystemDTOs.Roles;

namespace MedicalAppointment.Application.Contracts_Interfaces_.System
{
    public interface IRolesService : IBaseService<SaveRolesDTO, UpdateRolesDTO, RemoveRolesDTO, int>
    {
    }
}
