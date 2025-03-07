using MedicalAppointment.Application.Contracts_Interfaces_.System;
using MedicalAppointment.Application.DTOs.SystemDTOs.Status;
using MedicalAppointment.Application.Services.AppointmentsServices;
using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.System;
using MedicalAppointment.Persistence.Interfaces.SystemRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.SystemServices
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _repository;
        private readonly ILogger<AppointmentsService> _logger;
        private readonly IConfiguration _configuration;

        public StatusService(IStatusRepository repository, ILogger<AppointmentsService> logger, IConfiguration configuration)
        {
            _repository = repository;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<OperationResult> GetAll() => await _repository.GetAllAsync();

        public async Task<OperationResult> GetById(int id) => await _repository.GetEntityByIdAsync(id);

        public async Task<OperationResult> Remove(int id) => await _repository.RemoveEntityAsync(id);

        public async Task<OperationResult> Save(SaveStatusDTO data)
        {
            OperationResult result = new();

            try
            {
                Status status = new()
                {
                    StatusName = data.StatusName,
                };

                result = await _repository.SaveEntityAsync(status);

                if (!result.Success) throw new Exception(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Update(UpdateStatusDTO data)
        {
            OperationResult result = new();

            try
            {
                Status status = new()
                {
                    StatusName = data.StatusName,
                };

                result = await _repository.UpdateEntityAsync(status);

                if (!result.Success) throw new Exception(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
