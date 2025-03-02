namespace MedicalAppointment.Application.DTOs.AppointmentsDTOs.Appointments
{
    public record UpdateAppointmentDTO : BaseAppointmentDTO
    {
        public int AppointmentId { get; set; }
    }
}
