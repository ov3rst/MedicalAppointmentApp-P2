using MedicalAppointment.Domain.Base;

namespace MedicalAppointment.Application.Contracts_Interfaces_
{
    public interface IAppHttpClient
    {
        Task<OperationResult> GetResourseAsync(string route);
        Task<OperationResult> PostResourseAsync(string route, object data);
        Task<OperationResult> PutResourseAsync(string route, object data);
        Task<OperationResult> DeleteResourseAsync(string route, int data);
    }
}
