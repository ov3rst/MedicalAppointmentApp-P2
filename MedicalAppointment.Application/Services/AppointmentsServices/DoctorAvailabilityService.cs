using MedicalAppointment.Application.Contracts_Interfaces_.Appointments;
using MedicalAppointment.Application.DTOs.AppointmentsDTOs.DoctorAvailability;
using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Appointments;
using MedicalAppointment.Persistence.Interfaces.AppointmentsRepositories;
using MedicalAppointment.Persistence.Validations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.AppointmentsServices
{
    public class DoctorAvailabilityService : IDoctorAvailabilityService
    {
        private readonly IDoctorAvailabilityRepository _repository;
        private readonly ILogger<AppointmentsService> _logger;
        private readonly IConfiguration _configuration;

        public DoctorAvailabilityService(IDoctorAvailabilityRepository repository, ILogger<AppointmentsService> logger, IConfiguration configuration)
        {
            _repository = repository;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<OperationResult> GetAll() => await _repository.GetAllAsync();

        public async Task<OperationResult> GetById(int id) => await _repository.GetEntityByIdAsync(id);

        public async Task<OperationResult> Remove(int id) => await _repository.RemoveEntityAsync(id);

        public async Task<OperationResult> Save(SaveDoctorAvailabilityDTO data)
        {
            OperationResult result = new();

            try
            {
                BaseValidations.ValidateDate(BaseValidations.ToDateTime(data.AvailableDate));
                if (!result.Success) throw new Exception(result.Message);

                DoctorAvailability doctorAvailability = new()
                {
                    DoctorID = data.DoctorID,
                    AvailableDate = data.AvailableDate,
                    StartTime = data.StartTime,
                    EndTime = data.EndTime,
                };

                result = await _repository.SaveEntityAsync(doctorAvailability);

                if (!result.Success) throw new Exception(_configuration["ErrorDoctorAvailabilityRepository:SaveEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Update(UpdateDoctorAvailabilityDTO data)
        {
            OperationResult result = new();

            try
            {
                BaseValidations.ValidateDate(BaseValidations.ToDateTime(data.AvailableDate));
                if (!result.Success) throw new Exception(result.Message);

                DoctorAvailability doctorAvailability = new()
                {
                    Id = data.DoctorAvailabilityId,
                    DoctorID = data.DoctorID,
                    AvailableDate = data.AvailableDate,
                    StartTime = data.StartTime,
                    EndTime = data.EndTime,
                };

                result = await _repository.UpdateEntityAsync(doctorAvailability);

                if (!result.Success) throw new Exception(_configuration["ErrorDoctorAvailabilityRepository:UpdateEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
