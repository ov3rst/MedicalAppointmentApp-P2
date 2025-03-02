namespace MedicalAppointment.Application.DTOs.MedicalDTOs.AvailabilityModes
{
    public record UpdateAvailabilityModesDTO : BaseAvailabilityModesDTO
    {
        public int AvailabilityId { get; set; }
    }
}
