using MedicalAppointment.Application.DTOs.BaseDTOs;

namespace MedicalAppointment.Application.DTOs.SystemDTOs.Roles
{
    public abstract record BaseRolesDTO : BaseActiveDTO
    {
        public string RoleName { get; set; }
    }
}
