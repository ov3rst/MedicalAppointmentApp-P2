namespace MedicalAppointment.Application.DTOs.MedicalDTOs.MedicalRecords
{
    public record SaveMedicalRecordsDTO : BaseMedicalRecordsDTO
    {
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
    }
}
