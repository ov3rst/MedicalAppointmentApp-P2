namespace MedicalAppointment.Application.DTOs.UsersDTOs.Users
{
    public record UpdateUserDTO : BaseUserDTO
    {
        public int UserId { get; set; }
    }
}
