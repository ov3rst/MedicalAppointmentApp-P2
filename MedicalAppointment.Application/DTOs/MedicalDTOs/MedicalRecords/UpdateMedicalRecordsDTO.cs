namespace MedicalAppointment.Application.DTOs.MedicalDTOs.MedicalRecords
{
    public record UpdateMedicalRecordsDTO : BaseMedicalRecordsDTO
    {
        public int RecordId { get; set; }
    }
}
