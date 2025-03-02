using MedicalAppointment.Application.DTOs.BaseDTOs;

namespace MedicalAppointment.Application.DTOs.InsuranceDTOs.NetwrokTypes
{
    public abstract record BaseNetworkTypeDTO : BaseActiveDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
