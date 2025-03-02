namespace MedicalAppointment.Application.DTOs.UsersDTOs.Doctors
{
    public record UpdateDoctorDTO : BaseDoctorDTO
    {
        public int DoctorId { get; set; }
    }
}
