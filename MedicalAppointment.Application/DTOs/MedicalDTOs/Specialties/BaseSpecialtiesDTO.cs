using MedicalAppointment.Application.DTOs.BaseDTOs;

namespace MedicalAppointment.Application.DTOs.MedicalDTOs.Specialties
{
    public abstract record BaseSpecialtiesDTO : BaseActiveDTO
    {
        public string SpecialtyName { get; set; }
    }
}
