using MedicalAppointment.Application.Contracts_Interfaces_.Medical;
using MedicalAppointment.Application.DTOs.MedicalDTOs.AvailabilityModes;
using MedicalAppointment.Application.Services.AppointmentsServices;
using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Medical;
using MedicalAppointment.Persistence.Interfaces.MedicalRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.MedicalServices
{
    public class AvailabilityModesService : IAvailabilityModesService
    {
        private readonly IAvailabilityModesRepository _repository;
        private readonly ILogger<AppointmentsService> _logger;
        private readonly IConfiguration _configuration;

        public AvailabilityModesService(IAvailabilityModesRepository repository, ILogger<AppointmentsService> logger, IConfiguration configuration)
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

                if (!result.Success) throw new Exception(_configuration["ErrorAvailabilityModesRepository:GetAllAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> GetById(short id) => await _repository.GetEntityByIdAsync(id);

        public async Task<OperationResult> Save(SaveAvailabilityModesDTO data)
        {
            OperationResult result = new();

            try
            {
                AvailabilityModes modes = new()
                {
                    AvailabilityMode = data.AvailabilityMode,
                    CreatedAt = data.ChangeDate,
                    IsActive = data.IsActive,
                };

                result = await _repository.SaveEntityAsync(modes);

                if (!result.Success) throw new Exception(_configuration["ErrorAvailabilityModesRepository:SaveEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Update(UpdateAvailabilityModesDTO data)
        {
            OperationResult result = new();

            try
            {
                AvailabilityModes modes = new()
                {
                    Id = data.AvailabilityId,
                    AvailabilityMode = data.AvailabilityMode,
                    CreatedAt = data.ChangeDate,
                    IsActive = data.IsActive,
                };

                result = await _repository.SaveEntityAsync(modes);

                if (!result.Success) throw new Exception(_configuration["ErrorAvailabilityModesRepository:UpdateEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Remove(short id)
        {
            OperationResult result = new();

            try
            {
                result = await _repository.RemoveEntityAsync(id);

                if (!result.Success) throw new Exception(_configuration["ErrorAvailabilityModesRepository:RemoveEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
