using MedicalAppointment.Application.DTOs.BaseDTOs;

namespace MedicalAppointment.Application.DTOs.InsuranceDTOs.InsuranceProvider
{
    public record RemoveInsuranceProviderDTO : BaseDTO
    {
        public int InsuranceId { get; set; }
    }
}
