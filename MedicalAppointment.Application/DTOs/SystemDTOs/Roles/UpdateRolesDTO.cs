namespace MedicalAppointment.Application.DTOs.SystemDTOs.Roles
{
    public record UpdateRolesDTO : BaseRolesDTO
    {
        public int RoleId { get; set; }
    }
}
