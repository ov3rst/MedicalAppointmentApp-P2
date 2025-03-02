namespace MedicalAppointment.Application.DTOs.MedicalDTOs.Specialties
{
    public record UpdateSpecialtiesDTO : BaseSpecialtiesDTO
    {
        public short SpecialtyId { get; set; }
    }
}
