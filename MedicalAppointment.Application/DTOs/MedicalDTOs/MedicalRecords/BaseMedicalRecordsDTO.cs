using MedicalAppointment.Application.DTOs.BaseDTOs;

namespace MedicalAppointment.Application.DTOs.MedicalDTOs.MedicalRecords
{
    public abstract record BaseMedicalRecordsDTO : BaseDTO
    {
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public DateTime DateOfVisit { get; set; }
    }
}
