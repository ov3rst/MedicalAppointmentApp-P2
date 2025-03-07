using MedicalAppointment.Application.Contracts_Interfaces_.Medical;
using MedicalAppointment.Application.DTOs.MedicalDTOs.MedicalRecords;
using MedicalAppointment.Application.Services.AppointmentsServices;
using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Medical;
using MedicalAppointment.Persistence.Interfaces.MedicalRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.MedicalServices
{
    public class MedicalRecordsService : IMedicalRecordService
    {
        private readonly IMedicalRecordsRepository _repository;
        private readonly ILogger<AppointmentsService> _logger;
        private readonly IConfiguration _configuration;

        public MedicalRecordsService(IMedicalRecordsRepository repository, ILogger<AppointmentsService> logger, IConfiguration configuration)
        {
            _repository = repository;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<OperationResult> GetAll() => await _repository.GetAllAsync();

        public async Task<OperationResult> GetById(int id)
        {
            OperationResult result = new();

            try
            {
                result = await _repository.GetEntityByIdAsync(id);

                if (!result.Success) throw new Exception(_configuration["ErrorMedicalRecordsRepository:GetEntityByIdAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> GetMedicalRecordsByPacientId(int patientId)
        {
            OperationResult result = new();

            try
            {
                result = await _repository.GetMedicalRecordsByPacientId(patientId);

                if (!result.Success) throw new Exception(_configuration["ErrorMedicalRecordsRepository:GetMedicalRecordsByPacientId"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Save(SaveMedicalRecordsDTO data)
        {
            OperationResult result = new();

            try
            {
                MedicalRecords records = new()
                {
                    PatientID = data.PatientID,
                    DoctorID = data.DoctorID,
                    Diagnosis = data.Diagnosis,
                    Treatment = data.Treatment,
                    DateOfVisit = data.DateOfVisit,
                    CreatedAt = data.ChangeDate,
                };

                result = await _repository.SaveEntityAsync(records);

                if (!result.Success) throw new Exception(_configuration["ErrorMedicalRecordsRepository:SaveEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Update(UpdateMedicalRecordsDTO data)
        {
            OperationResult result = new();

            try
            {
                MedicalRecords records = new()
                {
                    Id = data.RecordId,
                    Diagnosis = data.Diagnosis,
                    Treatment = data.Treatment,
                    DateOfVisit = data.DateOfVisit,
                    UpdatedAt = data.ChangeDate,
                };

                result = await _repository.SaveEntityAsync(records);

                if (!result.Success) throw new Exception(_configuration["ErrorMedicalRecordsRepository:UpdateEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Remove(int id) => await _repository.RemoveEntityAsync(id);
    }
}
