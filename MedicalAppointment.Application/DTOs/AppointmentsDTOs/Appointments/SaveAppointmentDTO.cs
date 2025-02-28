namespace MedicalAppointment.Application.DTOs.AppointmentsDTOs.Appointments
{
    public record SaveAppointmentDTO : BaseAppointmentDTO
    {
        public int Id { get; set; }
    }
}
