using MedicalAppointment.Domain.Base;

namespace MedicalAppointment.Application.Contracts_Interfaces_
{
    public interface IAppHttpClient
    {
        Task<OperationResult> GetAsync(string route);
        Task<OperationResult> PostAsync(string route);
        Task<OperationResult> PutAsync(string route);
        Task<OperationResult> DeleteAsync(string route);
    }
}
