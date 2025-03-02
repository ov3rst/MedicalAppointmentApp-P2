namespace MedicalAppointment.Application.DTOs.SystemDTOs.Notification
{
    public record UpdateNotificationDTO : BaseNotificationDTO
    {
        public int NotificationId { get; set; }
    }
}
