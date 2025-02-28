namespace MedicalAppointment.Application.DTOs.InsuranceDTOs.InsuranceProvider
{
    public record UpdateInsuranceProviderDTO : BaseInsuranceProviderDTO
    {
        public int InsuranceId { get; set; }
    }
}
