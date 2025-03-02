namespace MedicalAppointment.Application.DTOs.SystemDTOs.Status
{
    public record UpdateStatusDTO : BaseStatusDTO
    {
        public int StatusId { get; set; }
    }
}
