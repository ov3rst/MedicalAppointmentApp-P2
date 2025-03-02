namespace MedicalAppointment.Application.DTOs.SystemDTOs.Notification
{
    public record SaveNotificationDTO : BaseNotificationDTO
    {
        public int UserId { get; set; }
    }
}
