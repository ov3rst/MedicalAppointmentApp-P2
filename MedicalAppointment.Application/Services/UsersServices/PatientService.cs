using MedicalAppointment.Application.Contracts_Interfaces_.Users;
using MedicalAppointment.Application.DTOs.UsersDTOs.Patients;
using MedicalAppointment.Application.Services.AppointmentsServices;
using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Users;
using MedicalAppointment.Persistence.Interfaces.UsersRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.UsersServices
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;
        private readonly ILogger<AppointmentsService> _logger;
        private readonly IConfiguration _configuration;

        public PatientService(IPatientRepository repository, ILogger<AppointmentsService> logger, IConfiguration configuration)
        {
            _repository = repository;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<OperationResult> GetAll()
        {
            OperationResult result = new();

            try
            {
                result = await _repository.GetAllAsync();
                if (!result.Success) throw new Exception(_configuration["ErrorPatientRepository:GetAllAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> GetById(int id)
        {
            OperationResult result = new();

            try
            {
                result = await _repository.GetEntityByIdAsync(id);
                if (!result.Success) throw new Exception(_configuration["ErrorPatientRepository:GetEntityByIdAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Remove(int id)
        {
            OperationResult result = new();

            try
            {
                result = await _repository.RemoveEntityAsync(id);
                if (!result.Success) throw new Exception(_configuration["ErrorPatientRepository:RemoveEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Save(SavePatientDTO data)
        {
            OperationResult result = new();

            try
            {
                Patient patient = new()
                {
                    DateOfBirth = data.DateOfBirth,
                    Gender = data.Gender,
                    PhoneNumber = data.PhoneNumber,
                    Address = data.Address,
                    EmergencyContactName = data.EmergencyContactName,
                    EmergencyContactPhone = data.EmergencyContactPhone,
                    BloodType = data.BloodType,
                    Allergies = data.Allergies,
                    InsuranceProviderId = data.InsuranceProviderId,
                    CreatedAt = data.ChangeDate,
                    IsActive = data.IsActive,
                };

                result = await _repository.SaveEntityAsync(patient);
                if (!result.Success) throw new Exception(_configuration["ErrorPatientRepository:SaveEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Update(UpdatePatientDTO data)
        {
            OperationResult result = new();

            try
            {
                Patient patient = new()
                {
                    Id = data.PatientId,
                    DateOfBirth = data.DateOfBirth,
                    Gender = data.Gender,
                    PhoneNumber = data.PhoneNumber,
                    Address = data.Address,
                    EmergencyContactName = data.EmergencyContactName,
                    EmergencyContactPhone = data.EmergencyContactPhone,
                    BloodType = data.BloodType,
                    Allergies = data.Allergies,
                    InsuranceProviderId = data.InsuranceProviderId,
                    UpdatedAt = data.ChangeDate,
                    IsActive = data.IsActive,
                };

                result = await _repository.UpdateEntityAsync(patient);
                if (!result.Success) throw new Exception(_configuration["ErrorPatientRepository:UpdateEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
