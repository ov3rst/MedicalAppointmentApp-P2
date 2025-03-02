using MedicalAppointment.Application.DTOs.BaseDTOs;

namespace MedicalAppointment.Application.DTOs.UsersDTOs.Users
{
    public abstract record BaseUserDTO : BaseActiveDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? RoleID { get; set; }
    }
}
