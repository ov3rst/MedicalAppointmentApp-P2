using MedicalAppointment.Application.DTOs.BaseDTOs;

namespace MedicalAppointment.Application.DTOs.MedicalDTOs.AvailabilityModes
{
    public abstract record BaseAvailabilityModesDTO : BaseActiveDTO
    {
        public string? AvailabilityMode { get; set; }
    }
}
