using MedicalAppointment.Application.DTOs.BaseDTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Application.DTOs.UsersDTOs.Doctors
{
    public abstract record BaseDoctorDTO : BaseActiveDTO
    {
        public short SpecialtyID { get; set; }
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public int YearsOfExperience { get; set; }
        public string Education { get; set; }
        public string? Bio { get; set; }
        public decimal? ConsultationFee { get; set; }
        public string? ClinicAddress { get; set; }

        [ForeignKey("AvailabilityModeId")]
        public short AvailabilityModeId { get; set; }
        public DateOnly LicenseExpirationDate { get; set; }
    }
}
