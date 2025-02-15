using MedicalAppointment.Domain.Entities.Medical;
using MedicalAppointment.Domain.Repository;

namespace MedicalAppointment.Persistence.Interfaces.MedicalRepositories
{
    public interface IMedicalRecordsRepository : IBaseRepository<MedicalRecords, int>
    {
    }
}
