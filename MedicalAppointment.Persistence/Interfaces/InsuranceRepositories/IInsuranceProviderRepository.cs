using MedicalAppointment.Domain.Entities.Insurance;
using MedicalAppointment.Domain.Repository;

namespace MedicalAppointment.Persistence.Interfaces.InsuranceRepositories
{
    public interface IInsuranceProviderRepository : IBaseRepository<InsuranceProvider, int>
    {
    }
}
