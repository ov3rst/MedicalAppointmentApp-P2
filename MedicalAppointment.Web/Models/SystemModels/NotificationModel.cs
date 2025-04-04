namespace MedicalAppointment.Web.Models.SystemModels
{
    public class NotificationModel
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public DateTime? SendAt { get; set; }
    }
}
