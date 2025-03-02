using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.DTOs.InsuranceDTOs.InsuranceProvider;

namespace MedicalAppointment.Application.Contracts_Interfaces_.Insurance
{
    public interface IInsuranceProviderService : IBaseService<SaveInsuranceProviderDTO, UpdateInsuranceProviderDTO, RemoveInsuranceProviderDTO, int>
    {
    }
}
