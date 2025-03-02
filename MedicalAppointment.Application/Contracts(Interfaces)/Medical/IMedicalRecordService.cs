using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.DTOs.MedicalDTOs.MedicalRecords;

namespace MedicalAppointment.Application.Contracts_Interfaces_.Medical
{
    public interface IMedicalRecordService : IBaseService<SaveMedicalRecordsDTO, UpdateMedicalRecordsDTO, RemoveMedicalRecordsDTO, int>
    {
    }
}
