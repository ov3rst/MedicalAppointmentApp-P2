using MedicalAppointment.Application.Contracts_Interfaces_.Users;
using MedicalAppointment.Application.DTOs.UsersDTOs.Doctors;
using MedicalAppointment.Application.Services.AppointmentsServices;
using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Users;
using MedicalAppointment.Persistence.Interfaces.UsersRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.UsersServices
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;
        private readonly ILogger<AppointmentsService> _logger;
        private readonly IConfiguration _configuration;

        public DoctorService(IDoctorRepository repository, ILogger<AppointmentsService> logger, IConfiguration configuration)
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
                if (!result.Success) throw new Exception(_configuration["ErrorDoctorRepository:GetAllAsync"]);
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
                if (!result.Success) throw new Exception(_configuration["ErrorDoctorRepository:GetEntityByIdAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> GetDoctorBySpecialty(int specialtyId)
        {
            OperationResult result = new();

            try
            {
                result = await _repository.GetDoctorBySpecialty(specialtyId);
                if (!result.Success) throw new Exception(_configuration["ErrorDoctorRepository:GetDoctorBySpecialty"]);
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
                if (!result.Success) throw new Exception(_configuration["ErrorDoctorRepository:RemoveEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Save(SaveDoctorDTO data)
        {
            OperationResult result = new();

            try
            {
                Doctor doctor = new()
                {
                    SpecialtyID = data.SpecialtyID,
                    LicenseNumber = data.LicenseNumber,
                    PhoneNumber = data.PhoneNumber,
                    YearsOfExperience = data.YearsOfExperience,
                    Education = data.Education,
                    Bio = data.Bio,
                    ConsultationFee = data.ConsultationFee,
                    ClinicAddress = data.ClinicAddress,
                    AvailabilityModeId = data.AvailabilityModeId,
                    LicenseExpirationDate = data.LicenseExpirationDate,
                    CreatedAt = data.ChangeDate,
                    IsActive = data.IsActive,
                };

                result = await _repository.SaveEntityAsync(doctor);
                if (!result.Success) throw new Exception(_configuration["ErrorDoctorRepository:SaveEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Update(UpdateDoctorDTO data)
        {
            OperationResult result = new();

            try
            {
                Doctor doctor = new()
                {
                    Id = data.DoctorId,
                    SpecialtyID = data.SpecialtyID,
                    LicenseNumber = data.LicenseNumber,
                    PhoneNumber = data.PhoneNumber,
                    YearsOfExperience = data.YearsOfExperience,
                    Education = data.Education,
                    Bio = data.Bio,
                    ConsultationFee = data.ConsultationFee,
                    ClinicAddress = data.ClinicAddress,
                    AvailabilityModeId = data.AvailabilityModeId,
                    LicenseExpirationDate = data.LicenseExpirationDate,
                    UpdatedAt = data.ChangeDate,
                    IsActive = data.IsActive,
                };

                result = await _repository.UpdateEntityAsync(doctor);
                if (!result.Success) throw new Exception(_configuration["ErrorDoctorRepository:UpdateEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
