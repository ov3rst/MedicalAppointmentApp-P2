namespace MedicalAppointment.Application.DTOs.AppointmentsDTOs.DoctorAvailability
{
    public record UpdateDoctorAvailabilityDTO : BaseDoctorAvailabilityDTO
    {
        public int DoctorAvailabilityId { get; set; }
    }
}
