namespace MedicalAppointment.Application.DTOs.MedicalDTOs.AvailabilityModes
{
    public record UpdateAvailabilityModesDTO : BaseAvailabilityModesDTO
    {
        public short AvailabilityId { get; set; }
    }
}
