using MedicalAppointment.Application.Contracts_Interfaces_.Appointments;
using MedicalAppointment.Application.DTOs.AppointmentsDTOs.Appointments;
using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Appointments;
using MedicalAppointment.Persistence.Interfaces.AppointmentsRepositories;
using MedicalAppointment.Persistence.Validations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.AppointmentsServices
{
    public class AppointmentsService : IAppointmentService
    {
        private readonly IAppointmentsRepository _repository;
        private readonly ILogger<AppointmentsService> _logger;
        private readonly IConfiguration _configuration;

        public AppointmentsService(IAppointmentsRepository repository, ILogger<AppointmentsService> logger, IConfiguration configuration)
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

                if (!result.Success) throw new Exception(_configuration["ErrorAppointmentsRepository:GetAllAsync"]);
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

                if (!result.Success) throw new Exception(_configuration["ErrorAppointmentsRepository:GetEntityByIdAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Save(SaveAppointmentDTO data)
        {
            OperationResult result = new();

            try
            {
                result = BaseValidations.ValidateDate(data.AppointmentDate);
                if (!result.Success) throw new Exception(result.Message);

                Appointments appointment = new Appointments
                {
                    DoctorID = data.DoctorID,
                    PatientID = data.PatientID,
                    AppointmentDate = data.AppointmentDate,
                    StatusID = data.StatusID,
                    CreatedAt = data.ChangeDate,
                };

                result = await _repository.SaveEntityAsync(appointment);

                if (!result.Success) throw new Exception(_configuration["ErrorAppointmentsRepository:SaveEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Update(UpdateAppointmentDTO data)
        {
            OperationResult result = new();

            try
            {
                BaseValidations.ValidateDate(data.AppointmentDate);
                if (!result.Success) throw new Exception(result.Message);

                Appointments appointment = new Appointments
                {
                    DoctorID = data.DoctorID,
                    PatientID = data.PatientID,
                    AppointmentDate = data.AppointmentDate,
                    StatusID = data.StatusID,
                    UpdatedAt = data.ChangeDate,
                };

                result = await _repository.UpdateEntityAsync(appointment);

                if (!result.Success) throw new Exception(_configuration["ErrorAppointmentsRepository:UpdateEntityAsync"]);
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
                if (!result.Success) throw new Exception(_configuration["ErrorAppointmentsRepository:RemoveEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
