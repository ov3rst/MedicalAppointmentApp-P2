using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.DTOs.InsuranceDTOs.NetwrokTypes;

namespace MedicalAppointment.Application.Contracts_Interfaces_.Insurance
{
    public interface INetworkTypeService : IBaseService<SaveNetworkTypeDTO, UpdateNetworkTypeDTO, RemoveNetworkTypeDTO, int>
    {
    }
}
