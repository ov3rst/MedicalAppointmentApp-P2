namespace MedicalAppointment.Application.DTOs.UsersDTOs.Patients
{
    public record UpdatePatientDTO : BasePatientDTO
    {
        public int PatientId { get; set; }
    }
}
