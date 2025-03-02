namespace MedicalAppointment.Application.DTOs.SystemDTOs.Notification
{
    public abstract record BaseNotificationDTO
    {
        public string Message { get; set; }
        public DateTime? SendAt { get; set; }
    }
}
