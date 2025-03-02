namespace MedicalAppointment.Application.DTOs.InsuranceDTOs.NetwrokTypes
{
    public record UpdateNetworkTypeDTO : BaseNetworkTypeDTO
    {
        public int NetworkId { get; set; }
    }
}
